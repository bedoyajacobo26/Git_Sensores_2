int pinButton = 15;
int buttonValue;
int valueAnt = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  pinMode(pinButton, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  buttonValue = digitalRead(pinButton);


  if (buttonValue == 1)
  {
    if (valueAnt != buttonValue)
    {
      //Serial.println(buttonValue);
      Serial.write(buttonValue);
      valueAnt = buttonValue;
    }
  }

  if (buttonValue == 0)
  {
    if (valueAnt != buttonValue)
    {
      valueAnt = buttonValue;
    }
  }

  

}
