# Processamento de Imagem — Projeto Final

Projeto desenvolvido no âmbito da unidade curricular de **Processamento de Imagem** (ISCTE-IUL), implementado em **C# com EmguCV (OpenCV para .NET)**.

## Descrição

O projeto consiste numa aplicação de processamento de imagem que implementa manualmente os algoritmos mais relevantes da área, com acesso direto à memória da imagem para maior desempenho. O caso de uso principal é o **reconhecimento automático de cartas de baralho** através de segmentação, análise de histograma e comparação de imagens.

## Funcionalidades Implementadas

### Operações de Cor e Brilho
- **Negativo** — inversão de cor de cada pixel
- **Escala de Cinza** — conversão RGB → gray pela média dos canais
- **Brilho e Contraste** — ajuste linear de intensidade
- **Canais RGB** — extração individual dos canais vermelho, verde e azul

### Transformações Geométricas
- **Translação** — deslocamento horizontal/vertical
- **Rotação** — rotação em torno do centro da imagem
- **Escala** — redimensionamento com ponto de escala configurável

### Filtros e Suavização
- **Filtro da Média** — suavização por média de vizinhança
- **Filtro Não-Uniforme** — convolução com matriz personalizada
- **Filtro da Mediana** — redução de ruído salt-and-pepper

### Detecção de Contornos / Gradiente
- **Sobel** — cálculo do gradiente em X e Y
- **Diferenciação** — derivada discreta simples
- **Roberts** — operador de Roberts cruzado

### Histograma e Binarização
- **Histograma** — cálculo para canal cinza, RGB individual e todos os canais
- **Binarização com Threshold** — conversão para preto e branco com limiar manual
- **Binarização de Otsu** — threshold automático pelo método de Otsu
- **Segmentação HSV** — binarização baseada em matiz (detecção de vermelho e preto)

### Reconhecimento de Cartas
- **Segmentação de Imagem** — identificação de regiões de interesse
- **Corte de Carta** — recorte automático da região da carta
- **Rotação de Carta** — alinhamento automático
- **Comparação de Pixels** — métrica de similaridade entre imagens
- **FindImage** — reconhecimento da carta por comparação com base de dados

## Tecnologias

| Tecnologia | Detalhe |
|---|---|
| Linguagem | C# (.NET Framework) |
| Biblioteca de Visão Computacional | EmguCV (wrapper OpenCV) |
| Interface Gráfica | Windows Forms |
| Acesso à Memória | Ponteiros `unsafe` para máxima performance |

## Estrutura do Repositório

```
├── ImageClass.cs       # Implementação de todos os algoritmos de processamento
├── ProjetoFinal.pdf    # Relatório do projeto final
└── RelatorioPI.pdf     # Relatório de Processamento de Imagem
```

## Documentação

- [`RelatorioPI.pdf`](./RelatorioPI.pdf) — Relatório técnico com descrição dos algoritmos e resultados
- [`ProjetoFinal.pdf`](./ProjetoFinal.pdf) — Relatório do projeto final com a implementação do reconhecimento de cartas

## Como Executar

1. Abrir a solução no **Visual Studio**
2. Garantir que o pacote **EmguCV** está instalado via NuGet
3. Compilar e executar — a aplicação Windows Forms apresenta os controlos para carregar imagens e aplicar os filtros

---

Desenvolvido por **Tiago** — ISCTE-IUL
