int J1_ledPin = 3;
int J1_pinPot = A1;
float J1_valPot = 0;

int J2_ledPin = 2;
int J2_pinPot = A0;
float J2_valPot = 0;

uint32_t timerPrev = 0;

void setup()
{
  Serial.begin(115200);
  
  pinMode(J1_ledPin, OUTPUT);
  pinMode(J1_pinPot, INPUT);

  pinMode(J2_ledPin, OUTPUT);
  pinMode(J2_pinPot, INPUT);

}

void loop()
{
  J1_valPot = analogRead(J1_pinPot);
  J2_valPot = analogRead(J2_pinPot);
  taskSend_pot();

  switch (Serial.read())
  {
    case 'A':

      digitalWrite(J1_ledPin, HIGH);
      delay(1000);
      digitalWrite(J1_ledPin, LOW);
      break;
    
    case 'B':

      digitalWrite(J2_ledPin, HIGH);
      delay(1000);
      digitalWrite(J2_ledPin, LOW);
      break;
  }
}

void taskSend_pot()
{
  uint32_t timer = millis();
  if ((timer - timerPrev) >= 33)
  {
    timerPrev = timer;
    Serial.print(J1_valPot);
    Serial.print(",");
    Serial.println(J2_valPot);
  }
}
