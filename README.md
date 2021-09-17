Interpretador de expressões aritméticas

Esse interpretador aplica-se a expressões completamente parentizadas, e considera apenas os operadores +, - e *, e os operandos números.

A partir de uma expressão já digitada corretamente e completamente parentizada, o interpretador faz a leitura caracter a caracter (sendo por caracter, os números considerados são formados por apenas um dígito, e inteiros), sendo seu funcionamento definido da seguinte forma: componentes: números inteiros, parênteses e operadores +, - e *
o que utilizar: duas pilhas, uma para os operandos e outra para os operadores
o que fazer a partir do reconhecimento de:
'(': não fazer nada
número: coloca-o na pilha de operandos
operador (+, - ou *): coloca-o na pilha de operadores
')': calcula sub-expressão, com os dois últimos números colocados na pilha de operandos (desempilha dois operandos) e o último sinal de operação colocado na pilha de operadores (desempilha um operador), empilhando-se o resultado na pilha de operadores.

Exercício: implementar um avaliador de expressões, usando duas pilhas, uma para os operandos, outra para os operadores. 
