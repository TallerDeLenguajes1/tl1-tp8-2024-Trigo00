/*#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAX 100

typedef struct Tarea Tarea;
typedef struct Nodo Nodo;

struct Tarea{
    int TareaID;//Numérico autoincremental comenzando en 1000
    char *Descripcion; //
    int Duracion; // entre 10 – 100
};

struct Nodo{
    Tarea T;
    Nodo *Siguiente;
};

//Funciones

Nodo** crearListaVacia();
Tarea cargarTarea(int* n);
void mostrarListaPendiente(Nodo** start);
void mostrarListaRealizada(Nodo** start);
Nodo* crearNodo(int* n);
void insertarNodo(Nodo** start, Nodo* nuevoNodo);
Nodo buscarTarea(Nodo** start, int id);
void eliminarNodo(Nodo** start, int id);
void buscarTareaPorId(Nodo** l1, Nodo** l2, int id);
void buscarPorPalabra(Nodo** startPend, Nodo** startReal, char *frase);



int main(){

    int numero = 1000;
    int condicion = 0;
    int cambiarTarea;
    int buscarPorId;
    char* buscarPalabra = (char*) malloc(sizeof(char) * MAX);


    //Armo el menu interactivo

    int opcion;
    Nodo** startPendientes = crearListaVacia();// Creo la lista enlazada de pendientes
    Nodo** startRealizadas = crearListaVacia();// Creo la lista enlazada de realizadas

    do
    {
        puts("\n\n MENU INTERACTIVO\n");
        puts("1) Agregar Tarea Pendiente");
        puts("2) Cambiar Tarea Pendiente a Tarea Realizada");
        puts("3) Mostrar Lista Pendiente");
        puts("4) Mostrar Lista Realizada");
        puts("5) Buscar Tarea por ID");
        puts("6) Buscar Tarea por Palabra Clave");
        puts("7) Salir");
        printf("\nIngrese la opcion deseada: ");
        fflush(stdin);
        scanf("%d", &opcion);

         switch (opcion)
        {
        case 1:
            do
            {
                insertarNodo(startPendientes, crearNodo(&numero));
                puts("\nTarea agregada correctamente");
                puts("\nDeseas agregar otra Tarea Pendiente:");
                puts("1) Si");
                puts("2) No");
                fflush(stdin);
                scanf("%d", &condicion);
            } while (condicion == 1);
            break;
        case 2:
            printf("\nElija la tarea de la Lista de Pendientes que desea pasar a la Lista de Realizadas(Ingrese ID): ");
            fflush(stdin);
            scanf("%d", &cambiarTarea);

            Nodo tareaEncontrada = buscarTarea(startPendientes, cambiarTarea);

            eliminarNodo(startPendientes, cambiarTarea);
            insertarNodo(startRealizadas, &tareaEncontrada);

            printf("\nLa tarea fue pasada correctamente");
            break;
        case 3:
            if(*startPendientes == NULL){
                printf("\nLa lista esta vacia");
            }else{
                mostrarListaPendiente(startPendientes);
            }
            break;
        case 4:
            if(*startRealizadas == NULL){
                printf("\nLa lista esta vacia");
            }else{
                mostrarListaRealizada(startRealizadas);
            }
            break;
        case 5:
            printf("\n\nIngrese el ID de la tarea buscada: ");
            fflush(stdin);
            scanf("%d", &buscarPorId);

            buscarTareaPorId(startPendientes, startRealizadas, buscarPorId);
            break;
        case 6:
            printf("\n\nIngrese una palabra clave por la cual quiere buscar una tarea: ");
            fflush(stdin);
            gets(buscarPalabra);
            buscarPalabra = (char*) realloc(buscarPalabra, sizeof(char) * (strlen(buscarPalabra) + 1));

            buscarPorPalabra(startPendientes, startRealizadas, buscarPalabra);
            break;
        case 7:
            break;
        default:
            printf("\nOpcion no valida. Por favor, ingrese una opcion valida.\n");
            break;
        }

    } while (opcion != 7);

    free(buscarPalabra);
   
    return 0;
}




Nodo** crearListaVacia(){
    Nodo** start = (Nodo**) malloc(sizeof(Nodo*));
    *start = NULL;
    return start;
    //return NULL; Si lo hago asi, se rompe, pero asi esta en la teoria
}

Tarea cargarTarea(int* n){

    Tarea nuevaTarea; //Creo una nueva tarea

    nuevaTarea.TareaID = (*n)++; //Incremento la variable n que pase por referencia, asi el id se va incrementando a partir de 1000, de 1 en 1

    nuevaTarea.Descripcion = (char*) malloc(sizeof(char) * MAX);//Asigno espacio MAX a la varible para recibir la descripcion
    printf("\nIngrese la descripcion de la tarea: ");
    fflush(stdin);
    gets(nuevaTarea.Descripcion);
    nuevaTarea.Descripcion = (char*) realloc(nuevaTarea.Descripcion, sizeof(char) * (strlen(nuevaTarea.Descripcion) + 1)); //Uso realloc para no usar memoria de mas

    nuevaTarea.Duracion = 10 + rand() % 91;// Doy los valores aleatorios entre 10 y 100

    return nuevaTarea; //Retorno la tarea que acabo de cargar y tiene todos los datos

}

Nodo* crearNodo(int* n){

    Nodo *nuevoNodo = (Nodo*) malloc(sizeof(Nodo)); //Doy memoria para el nuevo nodo

    nuevoNodo->T = cargarTarea(n); //Cargo como dato del nuevo nodo, a la tarea que recibo de la funcion cargarTarea
    nuevoNodo->Siguiente = NULL; // Hago que apunte a null, porque es el "primer" nodo que agrego

    return nuevoNodo; //Retorno el nodo o la "tarea" ya cargada y lista para insertar en la lista

}

void insertarNodo(Nodo** start, Nodo* nuevoNodo){

    nuevoNodo->Siguiente = *start; //El nodo que recibo como parametro hago que apunte hacia donde apunta la cabeza de la lista
    *start = nuevoNodo; // Hago que la cabeza de mi lista, sea el nodo. Es decir, si inserto por primera vez el nodo, en la linea anterior va a hacer que este apunte a null y luego lo nombro como la cabeza de la lista. Pero en el caso de que ya exista otro nodo en la lista, hago que el nuevo nodo, apunte a la cabeza de la lista anterior, es decir, a el nodo que ya esta dentro y luego redefino la cabeza de mi lista.

}

void mostrarListaPendiente(Nodo** start){

    Nodo* aux = *start; // Acá creo una variable auxiliar que simule la cabeza de la lista. Osea, que comience desde el principio. Hago esto para no perder datos a la hora de iterar.

    while(aux != NULL){ //Va a iterar siempre y cuando no llegue a null

        // Muestro todos los datos
        printf("\nInformacion de Tareas Pendientes\n");
        printf("\nID: %d", aux->T.TareaID);
        printf("\nDescripcion: %s", aux->T.Descripcion);
        printf("\nDuracion: %d", aux->T.Duracion);

        aux = aux->Siguiente; // Con esto voy pasando de nodo en nodo

    }

}

void mostrarListaRealizada(Nodo** start){

    // Todo lo que hago en esta funcion, es lo mismo que la anterior, solo que para listas de tareas realizadas
    Nodo* aux = *start;

    while(aux != NULL){

        printf("\n\nInformacion de Tareas Realizadas\n");
        printf("\nID: %d", aux->T.TareaID);
        printf("\nDescripcion: %s", aux->T.Descripcion);
        printf("\nDuracion: %d", aux->T.Duracion);

        aux = aux->Siguiente;

    }

}

Nodo buscarTarea(Nodo** start, int id){

    Nodo *buscada = (Nodo*) malloc(sizeof(Nodo)); // Creo un nuevo nodo, el cual me servira para retornalo con datos cargados

    buscada = *start; // Trabajo con una copia del puntero de inicio

    while(buscada->T.TareaID != id){ // Voy iterando siempre y cuando el id no sea igual. Cuando sea igual, me salgo y retorno el nodo que  buscaba.
        buscada = buscada->Siguiente;
    }

    return *buscada;

}

void eliminarNodo(Nodo** start, int id){

    Nodo** aux = start; // Acá creo una variable auxiliar que simule la cabeza de la lista. Osea, que comience desde el principio. Hago esto para no perder datos a la hora de iterar.

    while(*aux && (*aux)->T.TareaID != id){ // Itero siempre que no llegue al null y mientras no llegue al mismo id
        aux = &(*aux)->Siguiente; //Yo necesito recibir un doble puntero, entonces voy recorriendo la lista aux.
    }

    if(aux){ //Si no llegue a null
        Nodo* temp = *aux; // asigno a una nueva varible, el nodo en el que pare y quiero eliminar
        *aux = (*aux)->Siguiente; //Enlazo el anterior con el siguiente nodo del que quiero eliminar
        free(temp); //Elimino el nodo
    }

}

void buscarTareaPorId(Nodo** l1, Nodo** l2, int id){

    Nodo *tarea = *l1; // Acá creo una variable auxiliar que simule la cabeza de la lista. Osea, que comience desde el principio. Hago esto para no perder datos a la hora de iterar.
    int bandera = 0;

    if(*l1 == NULL && *l2 == NULL){ //En el caso que no tenga ningun dato cargado en las listas, estas estaran apuntando a null, entonces me fijo por esa condicion.
        printf("\nNo se encontraron tareas subidas para comparar");
    }else{// En el caso que si tenga datos en alguna de las 2 listas
        while(tarea != NULL && bandera == 0){ //Siempre y cuando no llegue al null o encuentre el id correspondiente y me cambie el valor de la bandera
            if(tarea->T.TareaID == id){// Si encuentro que el valor ingresado por el usuario y el id asignado a alguna tarea son los mismos
                //Muestro los datos
                puts("\nTarea encontrada, insertando datos...\n");
                puts("Tarea Pendiente");
                printf("ID: %d", tarea->T.TareaID);
                printf("\nDescripcion: %s", tarea->T.Descripcion);
                printf("\nDuracion: %d", tarea->T.Duracion);
                bandera = 1; //Cambio el valor de la bandera asi salgo del bucle y no entro a ningun if de abajo
            }
            tarea = tarea->Siguiente; // Con esto voy recorriendo la lista
        }

        if(bandera == 0){

            //Llegare a esta parte, en el caso que no encuentre en la lista de pendientes, una tarea que tenga el mismo id del ingresado por el usuario. Significa que nunca entro al if y nunca cambio el valor de la bandera, por eso sigue valiendo 0. Luego todo lo demas, es casi lo mismo, solo que busco en la lista de tareas realizadas
            tarea = *l2;

            while(tarea != NULL && bandera == 0){
                if(tarea->T.TareaID == id){
                    puts("\nTarea encontrada, insertando datos...\n");
                    puts("Tarea Realizada");
                    printf("ID: %d", tarea->T.TareaID);
                    printf("\nDescripcion: %s", tarea->T.Descripcion);
                    printf("\nDuracion: %d", tarea->T.Duracion);
                    bandera = 1;
                }
                tarea = tarea->Siguiente;
            }

        }

        if(bandera == 0){ // Y si no encuentro tampoco en la lista de tareas realizadas, es porque no existe una tarea con ese id
            printf("\nNo se encuentra una tarea que se identifique con ese ID. Intente nuevamente...");
        }
    }

    

}

void buscarPorPalabra(Nodo** startPend, Nodo** startReal, char* frase){
    Nodo* buscarPend = *startPend;
    Nodo* buscarReal = *startReal;
    int bandera = 0;

    //Esta funcion trabaja de la misma manera de cuando busco por el id. Lo unico "raro" o "distinto", es la funcion strstr(), que recibe 2 "string", el primero es la frase u oracion donde buscar y el 2do es la palabra clave que debo buscar. Va a buscar por toda la frase, y si encuentra, devuelve true.

    if(*startPend == NULL && *startReal == NULL){
        printf("\nNo se encontraron tareas subidas para comparar");
    }else{
        while (buscarPend != NULL && bandera == 0)
        {
            if (strstr(buscarPend->T.Descripcion, frase))
            {
                printf("\nID: %d\n", buscarPend->T.TareaID);
                printf("Descripcion: ");
                puts(buscarPend->T.Descripcion);
                printf("Duracion: %d\n", buscarPend->T.Duracion);
                bandera = 1;
            }
            buscarPend = buscarPend->Siguiente;
        }
        if (bandera == 0)
        {
            while (buscarReal != NULL && bandera == 0)
            {
                if (strstr(buscarReal->T.Descripcion, frase))
                {
                    printf("\nID: %d\n", buscarReal->T.TareaID);
                    printf("Descripcion: ");
                    puts(buscarReal->T.Descripcion);
                    printf("Duracion: %d\n", buscarReal->T.Duracion);
                    bandera = 1;    
                }          
            }
            buscarReal = buscarReal->Siguiente;
        }

        if(bandera == 0){
            printf("\nNo se encontraron resultados con la palabra clave: %s", frase);
        }
    }
    
}
*/