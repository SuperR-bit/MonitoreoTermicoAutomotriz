
/*

==============Codigo Version 1 - USADO EN PRUEBA NUMERO 7 DEL SENSOR ANALOGICO==============

String inputString = ""; //a String to hold incoming data
bool stringComplete = false; // whether the string is complete

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(LED_BUILTIN,OUTPUT);
  digitalWrite(LED_BUILTIN,LOW);
  Serial.println("Hola Mundo");

}

void loop() { 
  // put your main code here, to run repeatedly:
  if (stringComplete){
    inputString.trim();
    Serial.println(inputString);
    //process the command
    if (inputString.equals("$On")){
      digitalWrite(LED_BUILTIN,HIGH);
    }
    else if (inputString.equals("$Off"))
    {
      digitalWrite(LED_BUILTIN,LOW);
    }

    //clear the string: 
    inputString = "";
    stringComplete = false;


  }

}

void serialEvent()
{
  while(Serial.available()){
    //get the new byte:
    char inChar = (char)Serial.read();
    if (inChar == '\n'){
      stringComplete = true;
    }
    else{
      //add it t the inputString:
      inputString += inChar;
    }
  }
}
*/




/*

==============Codigo Version 2 - USADO EN PRUEBA NUMERO 8 DEL SENSOR ANALOGICO==============

// Variables para la comunicación serial
String inputString = ""; 
bool stringComplete = false; 

//Variable de control de estado del sistema 
bool sistemaActivo = false; 


// Variables para el sensor de temperatura y rangos
float tempMin = 18.0; // Límite inferior predeterminado
float tempMax = 24.0; // Límite superior predeterminado
unsigned long previoMillis = 0;
const long intervalo = 1000; // Envía datos cada 1 segundo

// Pines de Actuadores
const int PIN_BUZZER = 8;  // pin para el buzzer
const int PIN_LED_TEMP = 9; // LED indicador físico

void setup() {
  Serial.begin(9600);
  
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(PIN_BUZZER, OUTPUT);
  pinMode(PIN_LED_TEMP, OUTPUT);
  
  digitalWrite(LED_BUILTIN, LOW);
  digitalWrite(PIN_BUZZER, LOW);
  digitalWrite(PIN_LED_TEMP, LOW);

  apagarTodoElHardware();
}

void loop() {
  // PROCESAR COMANDOS DESDE EL HMI 
  if (stringComplete) {
    inputString.trim();
    
    // Control manual del LED integrado
    if (inputString.equals("$On")) {
      digitalWrite(LED_BUILTIN, HIGH);
    }
    else if (inputString.equals("$Off")) {
      digitalWrite(LED_BUILTIN, LOW);
    }
    // Configuración dinámica de rangos desde el HMI (Formato esperado: L:15.5 o H:28.0)
    else if (inputString.startsWith("L:")) {
      tempMin = inputString.substring(2).toFloat();
    }
    else if (inputString.startsWith("H:")) {
      tempMax = inputString.substring(2).toFloat();
    }

    // Limpiar string
    inputString = "";
    stringComplete = false;
  }

  // LECTURA DE TEMPERATURA Y ENVÍO AL HMI 
  unsigned long actualMillis = millis();
  if (actualMillis - previoMillis >= intervalo) {
    previoMillis = actualMillis;

    // Leer sensor
    int value = analogRead(A0);
    float volts = (value * 5.0) / 1023.0;
    float celsius = volts * 100.0;

    // Determinar estado de alerta
    String estado = "NORMAL";
    if (celsius > tempMax) {
      estado = "ALTA";
      digitalWrite(PIN_BUZZER, HIGH); // Activa buzzer físico
      digitalWrite(PIN_LED_TEMP, HIGH);
    } 
    else if (celsius < tempMin) {
      estado = "BAJA";
      digitalWrite(PIN_BUZZER, HIGH); // Activa buzzer físico
      digitalWrite(PIN_LED_TEMP, HIGH);
    } 
    else {
      digitalWrite(PIN_BUZZER, LOW);  // Apaga alertas físicas
      digitalWrite(PIN_LED_TEMP, LOW);
    }

    // Enviar datos formateados al HMI: "Temperatura,Estado,Min,Max"
    // Ejemplo: "25.34,ALTA,18.00,24.00"
    Serial.print(celsius);
    Serial.print(",");
    Serial.print(estado);
    Serial.print(",");
    Serial.print(tempMin);
    Serial.print(",");
    Serial.println(tempMax); 
  }
}

//Funcion que apaga todas las salidas fisicas de golpe
void apagarTodoElHardware() {
  digitalWrite(LED_BUILTIN, LOW);
  digitalWrite(PIN_BUZZER, LOW);
  digitalWrite(PIN_LED_TEMP, LOW);
}


// Evento Serial automático
void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n') {
      stringComplete = true;
    } else {
      inputString += inChar;
    }
  }
}

*/



/*

==============Codigo Version 3 - USADO EN PRUEBA NUMERO 9 DEL SENSOR ANALOGICO==============

// Variables para la comunicación serial
String inputString = ""; 
bool stringComplete = false; 

// Variable de control de estado del sistema 
bool sistemaActivo = false; 

// Variables para el sensor de temperatura y rangos
float tempMin = 18.0; 
float tempMax = 24.0; 
unsigned long previoMillis = 0;
const long intervalo = 1000; 

// Pines de Actuadores
const int PIN_BUZZER = 8;  
const int PIN_LED_TEMP = 9; 

void setup() {
  Serial.begin(9600);
  
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(PIN_BUZZER, OUTPUT);
  pinMode(PIN_LED_TEMP, OUTPUT);
  
  // Asegurar estado inicial apagado
  apagarTodoElHardware();
}

void loop() {
  // PROCESAR COMANDOS DESDE EL HMI
  if (stringComplete) {
    inputString.trim();
    
    // Control general de encendido y apagado del sistema
    if (inputString.equals("$On")) {
      sistemaActivo = true;
      digitalWrite(LED_BUILTIN, HIGH); // Luz de sistema operando
    }
    else if (inputString.equals("$Off")) {
      sistemaActivo = false;
      apagarTodoElHardware(); // Apagado inmediato de seguridad
    }
    // Configuración de rangos
    else if (inputString.startsWith("L:")) {
      tempMin = inputString.substring(2).toFloat();
    }
    else if (inputString.startsWith("H:")) {
      tempMax = inputString.substring(2).toFloat();
    }

    inputString = "";
    stringComplete = false;
  }

  // OPERACIÓN Y MONITOREO (Solo si el HMI activó el sistema)
  if (sistemaActivo) {
    unsigned long actualMillis = millis();
    if (actualMillis - previoMillis >= intervalo) {
      previoMillis = actualMillis;

      // Leer sensor
      int value = analogRead(A0);
      float volts = (value * 5.0) / 1023.0;
      float celsius = volts * 100.0;

      // Determinar estado de alerta
      String estado = "NORMAL";
      if (celsius > tempMax) {
        estado = "ALTA";
        digitalWrite(PIN_BUZZER, HIGH); 
        digitalWrite(PIN_LED_TEMP, HIGH);
      } 
      else if (celsius < tempMin) {
        estado = "BAJA";
        digitalWrite(PIN_BUZZER, HIGH); 
        digitalWrite(PIN_LED_TEMP, HIGH);
      } 
      else {
        digitalWrite(PIN_BUZZER, LOW);  
        digitalWrite(PIN_LED_TEMP, LOW);
      }

      // Enviar datos formateados al HMI
      Serial.print(celsius);
      Serial.print(",");
      Serial.print(estado);
      Serial.print(",");
      Serial.print(tempMin);
      Serial.print(",");
      Serial.println(tempMax); 
    }
  }
}

// Función auxiliar para apagar todas las salidas físicas de golpe
void apagarTodoElHardware() {
  digitalWrite(LED_BUILTIN, LOW);
  digitalWrite(PIN_BUZZER, LOW);
  digitalWrite(PIN_LED_TEMP, LOW);
}

// Evento Serial automático
void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n') {
      stringComplete = true;
    } else {
      inputString += inChar;
    }
  }
}

*/

/*==============Codigo Version 4 - USADO EN PRUEBA NUMERO 5 DEL SENSOR ANALOGICO==============*/
//NOTA: ESTE CODIGO YA NO FUNCIONA EN EL HMI, SE TIENE QUE INTEGRAR EL PROCESAMIENTO COMANDO RANGOS

// Variables para la comunicación serial
String inputString = ""; 
bool stringComplete = false; 

// Variable de control de estado del sistema 
bool sistemaActivo = false; 

// Variables para el sensor de temperatura y rangos
float tempMin = 18.0; 
float tempMax = 24.0; 
unsigned long previoMillis = 0;
const long intervalo = 1000; 

// Pines de Actuadores
const int PIN_BUZZER = 8;  
const int PIN_LED_TEMP = 9; 

void setup() {
  Serial.begin(9600);
  
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(PIN_BUZZER, OUTPUT);
  pinMode(PIN_LED_TEMP, OUTPUT);
  
  // Funcion que asegurar que el estado inicial sea apagado al arrancar el Arduino
  apagarTodoElHardware();
}

void loop() {
  // PROCESAR COMANDOS DESDE EL HMI
  if (stringComplete) {
    inputString.trim();
    
    if (inputString.equals("$On")) {
      sistemaActivo = true;
      digitalWrite(LED_BUILTIN, HIGH); // Indicador visual de sistema operando
    }
    else if (inputString.equals("$Off")) {
      sistemaActivo = false;
      apagarTodoElHardware(); // Apagado inmediato de seguridad de los actuadores
    }
    else if (inputString.startsWith("L:")) {
      tempMin = inputString.substring(2).toFloat();
    }
    else if (inputString.startsWith("H:")) {
      tempMax = inputString.substring(2).toFloat();
    }

    inputString = "";
    stringComplete = false;
  }

  // OPERACIÓN Y MONITOREO (Solo si sistemaActivo es true)
  if (sistemaActivo) {
    unsigned long actualMillis = millis();
    if (actualMillis - previoMillis >= intervalo) {
      previoMillis = actualMillis;

      // Leer sensor LM35
      int value = analogRead(A0);
      float volts = (value * 5.0) / 1023.0;
      float celsius = volts * 100.0;

      // Determinar estado de alerta
      String estado = "NORMAL";
      if (celsius > tempMax || celsius < tempMin) {
        estado = (celsius > tempMax) ? "ALTA" : "BAJA";
        digitalWrite(PIN_BUZZER, HIGH); 
        digitalWrite(PIN_LED_TEMP, HIGH);
      } 
      else {
        digitalWrite(PIN_BUZZER, LOW);  
        digitalWrite(PIN_LED_TEMP, LOW);
      }

      // Enviar datos formateados al HMI
      Serial.print(celsius);
      Serial.print(",");
      Serial.print(estado);
      Serial.print(",");
      Serial.print(tempMin);
      Serial.print(",");
      Serial.println(tempMax); 
    }
  }
}

// Función para apagar todas las salidas físicas 
void apagarTodoElHardware() {
  digitalWrite(LED_BUILTIN, LOW);
  digitalWrite(PIN_BUZZER, LOW);
  digitalWrite(PIN_LED_TEMP, LOW);
}

// Evento Serial automático
void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n') {
      stringComplete = true;
    } else {
      inputString += inChar;
    }
  }
}


/*==============Codigo Version 5 - USADO EN PRUEBA NUMERO 5 DEL SENSOR ANALOGICO==============*/
//NOTA: VERSION QUE INTEGRA EL COMANDO RANGOS, NO SE PROBO

/*
// Variables para la comunicación serial
String inputString = ""; 
bool stringComplete = false; 
bool sistemaActivo = false; 

// Variables para el sensor de temperatura y rangos
float tempMin = 18.0; 
float tempMax = 24.0; 
unsigned long previoMillis = 0;
const long intervalo = 1000; 

// Pines de Actuadores
const int PIN_BUZZER = 8;  
const int PIN_LED_TEMP = 9; 

void setup() {
  Serial.begin(9600);
  
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(PIN_BUZZER, OUTPUT);
  pinMode(PIN_LED_TEMP, OUTPUT);
  
  apagarTodoElHardware();
}

void loop() {
  // PROCESAR COMANDOS DESDE EL HMI (Actualizado)
  if (stringComplete) {
    inputString.trim();
    
    if (inputString.equals("$On")) {
      sistemaActivo = true;
      digitalWrite(LED_BUILTIN, HIGH); 
    }
    else if (inputString.equals("$Off")) {
      sistemaActivo = false;
      apagarTodoElHardware(); 
    }
    // NUEVO PARSEADOR: Ahora el LM35 recibe ambos límites juntos
    else if (inputString.startsWith("RANGOS:")) {
      String datosRangos = inputString.substring(7); 
      int comaIndex = datosRangos.indexOf(',');
      if (comaIndex != -1) {
        String minStr = datosRangos.substring(0, comaIndex);
        String maxStr = datosRangos.substring(comaIndex + 1);
        
        tempMin = minStr.toFloat();
        tempMax = maxStr.toFloat();
      }
    }

    inputString = "";
    stringComplete = false;
  }

  // OPERACIÓN Y MONITOREO 
  if (sistemaActivo) {
    unsigned long actualMillis = millis();
    if (actualMillis - previoMillis >= intervalo) {
      previoMillis = actualMillis;

      // Leer sensor LM35
      int value = analogRead(A0);
      float volts = (value * 5.0) / 1023.0;
      float celsius = volts * 100.0;

      // Determinar estado de alerta
      String estado = "NORMAL";
      if (celsius > tempMax || celsius < tempMin) {
        estado = (celsius > tempMax) ? "ALTA" : "BAJA";
        digitalWrite(PIN_BUZZER, HIGH); 
        digitalWrite(PIN_LED_TEMP, HIGH);
      } 
      else {
        digitalWrite(PIN_BUZZER, LOW);  
        digitalWrite(PIN_LED_TEMP, LOW);
      }

      // Enviar datos formateados al HMI
      Serial.print(celsius);
      Serial.print(",");
      Serial.print(estado);
      Serial.print(",");
      Serial.print(tempMin);
      Serial.print(",");
      Serial.println(tempMax); 
    }
  }
}

void apagarTodoElHardware() {
  digitalWrite(LED_BUILTIN, LOW);
  digitalWrite(PIN_BUZZER, LOW);
  digitalWrite(PIN_LED_TEMP, LOW);
}

void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n') {
      stringComplete = true;
    } else {
      inputString += inChar;
    }
  }
}


*/















