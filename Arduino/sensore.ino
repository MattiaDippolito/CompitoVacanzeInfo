#define Trigger1 9
#define Echo1 10
int contatore;
bool attivo = false;

void setup(){
  pinMode(Trigger1,OUTPUT);
  pinMode(Echo1,INPUT);
  Serial.begin(9600);
  delay(100);
}

void loop()
{
    char c = Serial.read();
    if(c=='p'){
      attivo = true;
    }else if(c=='s'){
      attivo = false;
      Serial.print(contatore);
    }
    if(attivo){
      controlloSensore1();
    }else{
      contatore = 0;
    }
}

void controlloSensore1(){
  digitalWrite(Trigger1,LOW);
  digitalWrite(Trigger1,HIGH);
  delayMicroseconds(10);
  digitalWrite(Trigger1,LOW);
  
  long durata1 = pulseIn(Echo1,HIGH);
  long distanza1 = durata1/58.31;
  delay(100);
  
  if(distanza1<100){
    contatore++;
  }
}
