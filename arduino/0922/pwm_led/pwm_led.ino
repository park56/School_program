void setup() {

  Serial.begin(9600); // 시리얼의 보트레이트를 9600으로 설정

  Serial.println("haha"); // 시리얼 터미널에 haha출력

  pinMode(13,OUTPUT); // 13번 포트를 output으로 설정
}

int count = 0;
int count_100ms = 0;

int count_2 = 0;
int count_200ms = 0;

int duty = 1;
int duty2 = 1;

void loop() {
//  for (int i = 0; i<100; i++){
//    digitalWrite(13,HIGH);  // 포트 13번에 high(1) 을 줌
//    delay(9);  // 주기가 1초에 100번 -> 1000hz
//    digitalWrite(13,LOW);
//    delay(1);
//  }
//
//    for (int i = 0; i<100; i++){
//    digitalWrite(13,HIGH);  // 포트 13번에 high(1) 을 줌
//    delay(1);  // 주기가 1초에 50번 -> 50hz
//    digitalWrite(13,LOW);
//    delay(9);
//  }


 if (count_2 == 100) {
    count_2 = 0;
    digitalWrite(9,HIGH);
    digitalWrite(10,HIGH);
    digitalWrite(11,HIGH);
 }else if (count_2 == duty2) {
    digitalWrite(9,LOW);
    digitalWrite(10,LOW);
    digitalWrite(11,LOW);
 }

  if (count_200ms == 200){ // 200MS가 되면
    count_200ms =  0;
    duty2++;
    if (duty2==100) duty2 = 1;  // 200MS가 100번지나 duty가 100이 되면
  }

  //--------------------------
  if (count == 100) {
    count = 0;

    digitalWrite(13,HIGH); 
  }
  else if (count == duty) {
     digitalWrite(13,LOW);
  }
  //--------------------------

  if (count_100ms == 100){
    count_100ms = 0;
    duty++;
    if (duty == 99) duty = 1;
  }
  //--------------------------
  
  count++;
  
  count_100ms++;

  count_200ms++;
  
  count_2++;
  //delay(1);
  delayMicroseconds(100);
}
