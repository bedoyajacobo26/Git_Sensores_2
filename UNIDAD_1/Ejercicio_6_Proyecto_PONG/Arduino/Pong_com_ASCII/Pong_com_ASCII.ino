unsigned long last_time = 0;
int J2_ledPin = 2;
int J2_pinPot = A0;
float J2_valPot =0;
uint32_t timerPrev = 0;

void setup()
{
    Serial.begin(115200);
    pinMode(J2_ledPin, OUTPUT);
    pinMode(J2_pinPot, INPUT);
    
    
}

void loop()
{

    J2_valPot = analogRead(J2_pinPot);
    taskSend_J2pot();

    switch (Serial.read())
    {
        case 'B': 
            
            digitalWrite(J2_ledPin, HIGH);
            delay(1000);
            digitalWrite(J2_ledPin, LOW);
            break;
    }
}

void taskSend_J2pot()
{
  uint32_t timer = millis();
   if((timer - timerPrev) >= 33)
  {
     timerPrev = timer;
     Serial.println(J2_valPot);
  }
}
