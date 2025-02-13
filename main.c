#include <stdio.h>

int main(void) {
  int a;
  printf("Insira um numero\n");
  scanf("%d", &a);
  for(int i=1; i <= 100; i++) {
    if(i % a == 0) {
      printf("%d\n", i);
    }
  }
    
  return 0;
}