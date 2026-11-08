/*
==============Codigo Version 1 - USADO EN PRUEBA NUMERO 3 DEL SENSOR DIGITAL==============

#include <OneWire.h>
#include <DallasTemperature.h>

// Variables para la comunicación serial 
String inputString = ""; 
bool stringComplete = false; 
bool sistemaActivo = false; 

// Variables para rangos 
float tempMin = 18.0; 
float tempMax = 24.0; 
unsigned long previoMillis = 0;
const long intervalo = 1000; 

// CONFIGURACIÓN DIGITAL 
// Definimos que el pin digital 2 del Arduino se comunicará con el sensor.
const int PIN_KY001 = 2; 

// Creamos una instancia de OneWire para manejar el cable de datos en el pin 2.
OneWire oneWire(PIN_KY001);

// Le pasamos esa conexión a la librería DallasTemperature para que controle el sensor.
DallasTemperature sensors(&oneWire);

// Pines de Actuadores 
const int PIN_BUZZER = 8;  
const int PIN_LED_TEMP = 9; 

void setup() {
  Serial.begin(9600);
  
  // INICIALIZACIÓN 
  // Arranca el bus de datos digital para buscar sensores conectados.
  sensors.begin();
  
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(PIN_BUZZER, OUTPUT);
  pinMode(PIN_LED_TEMP, OUTPUT);
  
  apagarTodoElHardware();
}

void loop() {
  // Sigue reaccionando a "$On", "$Off", "L:" y "H:" de la misma forma.
  if (stringComplete) {
    inputString.trim();
    if (inputString.equals("$On")) { sistemaActivo = true; digitalWrite(LED_BUILTIN, HIGH); }
    else if (inputString.equals("$Off")) { sistemaActivo = false; apagarTodoElHardware(); }
    else if (inputString.startsWith("L:")) { tempMin = inputString.substring(2).toFloat(); }
    else if (inputString.startsWith("H:")) { tempMax = inputString.substring(2).toFloat(); }
    inputString = ""; stringComplete = false;
  }

  // OPERACIÓN Y MONITOREO
  if (sistemaActivo) {
    unsigned long actualMillis = millis();
    if (actualMillis - previoMillis >= intervalo) {
      previoMillis = actualMillis;

      // LECTURA DIGITAL 
      sensors.requestTemperatures(); 
      float celsius = sensors.getTempCByIndex(0);

      // BLINDAJE ANTI-ERRORES 
      // Si el cable del sensor digital se rompe o se desconecta, la librería no devuelve 0,
      // devuelve un valor especial de error llamado 'DEVICE_DISCONNECTED_C' (que equivale a -127°C).
      // Esta condición asegura que solo procesamos los datos si el sensor está realmente conectado.
      if (celsius != DEVICE_DISCONNECTED_C) {
        
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

        // TRANSMISIÓN AL HMI 
        // Mapea exactamente igual: "Temperatura,Estado,Min,Max"
        // Tu HMI en C# ni siquiera se enterará de que cambiaste de sensor, porque recibe 
        // el mismo formato de texto. El CSV y el gráfico funcionarán sin tocarles nada.
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
}

void apagarTodoElHardware() {
  digitalWrite(LED_BUILTIN, LOW);
  digitalWrite(PIN_BUZZER, LOW);
  digitalWrite(PIN_LED_TEMP, LOW);
}

void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n') { stringComplete = true; } 
    else { inputString += inChar; }
  }
}
*/




/*
==============Codigo Version 2.5 - USADO EN PRUEBA NUMERO 5 DEL SENSOR DIGITAL==============

#include <OneWire.h>
#include <DallasTemperature.h>

// Variables para la comunicación serial 
String inputString = ""; 
bool stringComplete = false; 
bool sistemaActivo = false; 

// Variables para rangos 
float tempMin = 18.0; 
float tempMax = 24.0; 
unsigned long previoMillis = 0;
const long intervalo = 1000; 

// CONFIGURACIÓN DIGITAL 
// Definimos que el pin digital 2 del Arduino se comunicará con el sensor.
const int PIN_KY001 = 2; 

// Creamos una instancia de OneWire para manejar el cable de datos en el pin 2.
OneWire oneWire(PIN_KY001);

// Le pasamos esa conexión a la librería DallasTemperature para que controle el sensor.
DallasTemperature sensors(&oneWire);

// Pines de Actuadores 
const int PIN_BUZZER = 8;  
const int PIN_LED_TEMP = 9; 

void setup() {
  Serial.begin(9600);
  
  // INICIALIZACIÓN 
  // Arranca el bus de datos digital para buscar sensores conectados.
  sensors.begin();
  
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(PIN_BUZZER, OUTPUT);
  pinMode(PIN_LED_TEMP, OUTPUT);
  
  apagarTodoElHardware();
}

void loop() {
  // Sigue reaccionando a "$On", "$Off", "L:" y "H:" de la misma forma.
  // 1. PROCESAR COMANDOS DESDE EL HMI
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
    // Procesa los dos límites juntos desde la sola trama del HMI
    else if (inputString.startsWith("RANGOS:")) {
      // Quitar la cabecera "RANGOS:"
      String datosRangos = inputString.substring(7); 
      
      // Encontrar la coma separadora
      int comaIndex = datosRangos.indexOf(',');
      if (comaIndex != -1) {
        String minStr = datosRangos.substring(0, comaIndex);
        String maxStr = datosRangos.substring(comaIndex + 1);
        
        // Convertir de texto a flotante e impactar inmediatamente las variables
        tempMin = minStr.toFloat();
        tempMax = maxStr.toFloat();
      }
    }

    inputString = "";
    stringComplete = false;
  }
}

  // OPERACIÓN Y MONITOREO
  if (sistemaActivo) {
    unsigned long actualMillis = millis();
    if (actualMillis - previoMillis >= intervalo) {
      previoMillis = actualMillis;

      // LA LECTURA DIGITAL 
      sensors.requestTemperatures(); 
      float celsius = sensors.getTempCByIndex(0);

      // BLINDAJE ANTI-ERRORES 
      // Si el cable del sensor digital se rompe o se desconecta, la librería no devuelve 0,
      // devuelve un valor especial de error llamado 'DEVICE_DISCONNECTED_C' (que equivale a -127°C).
      // Esta condición asegura que solo procesamos los datos si el sensor está realmente conectado.
      if (celsius != DEVICE_DISCONNECTED_C) {
        
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

        // TRANSMISIÓN AL HMI 
        // Mapea exactamente igual: "Temperatura,Estado,Min,Max"
        // Tu HMI en C# ni siquiera se enterará de que cambiaste de sensor, porque recibe 
        // el mismo formato de texto. El CSV y el gráfico funcionarán sin tocarles nada.
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
}

void apagarTodoElHardware() {
  digitalWrite(LED_BUILTIN, LOW);
  digitalWrite(PIN_BUZZER, LOW);
  digitalWrite(PIN_LED_TEMP, LOW);
}

void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n') { stringComplete = true; } 
    else { inputString += inChar; }
  }
}
*/




/*==============Codigo Version 3 - USADO EN PRUEBA NUMERO 4.1, 5.1 DEL SENSOR DIGITAL==============*/

#include <OneWire.h>
#include <DallasTemperature.h>

// Variables para la comunicación serial
String inputString = ""; 
bool stringComplete = false; 
bool sistemaActivo = false; 

// Variables para rangos
float tempMin = 18.0; 
float tempMax = 24.0; 
unsigned long previoMillis = 0;
const long intervalo = 1000; 

// CONFIGURACIÓN DIGITAL del modulo KY-001
const int PIN_KY001 = 2; 
OneWire oneWire(PIN_KY001);
DallasTemperature sensors(&oneWire);

// Pines de Actuadores
const int PIN_BUZZER = 8;  
const int PIN_LED_TEMP = 9; 

void setup() {
  Serial.begin(9600);
  
  // Inicialización del bus digital
  sensors.begin();
  
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(PIN_BUZZER, OUTPUT);
  pinMode(PIN_LED_TEMP, OUTPUT);
  
  apagarTodoElHardware();
}

void loop() {
  // PROCESAR COMANDOS DESDE EL HMI
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
    //else if (inputString.startsWith("L:")) { tempMin = inputString.substring(2).toFloat(); }
    //else if (inputString.startsWith("H:")) { tempMax = inputString.substring(2).toFloat(); }
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

      // Lectura del sensor digital
      sensors.requestTemperatures(); 
      float celsius = sensors.getTempCByIndex(0);

      // Blindaje si el sensor se desconecta
      if (celsius != DEVICE_DISCONNECTED_C) {
        
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

        // Transmisión unificada al HMI
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
}

void apagarTodoElHardware() {
  digitalWrite(LED_BUILTIN, LOW);
  digitalWrite(PIN_BUZZER, LOW);
  digitalWrite(PIN_LED_TEMP, LOW);
}

void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n') { stringComplete = true; } 
    else { inputString += inChar; }
  }
}


