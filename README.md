# Pseudoplanner (EN)
An sketch of an AI design pattern for videogames written in C#, designed to make organizing state machine logic transitions easier. The setup is basically two state machines, a local state state monitor and an optional world state monitor.

Behaviors are created from a predefined sequence of states - a list that is iterated based on logical conditions - so there's no real planning going on. It's pretty much a script or routine that the bot follows, making it look like it's rationalizing plans during gameplay. Hence the name "Pseudo-planner".

Inspired by elements from [GOAP](https://citeseerx.ist.psu.edu/document?repid=rep1&type=pdf&doi=0c35d00a015c93bac68475e8e1283b02701ff46b) logic and [Behavior Trees](https://en.wikipedia.org/wiki/Behavior_tree_(artificial_intelligence,_robotics_and_control)), but using state machines in tandem as a base.

### File summary
1. PseudoPlanner.cs
   The motor for the plans. Makes scripts update during runtine and has some methods for handling plan transitions and has a helper method for delayed logic.
2. PseudoPlannerBasePlan.cs
   The template script the plans derive from.
3. Flags.cs
   The boolean methods the script will check to evaluate the state list iterations.
5. PlanFlank.cs
   A concrete example of a plan.

*@2025 - Personal project. Authored by myself.*


# Pseudoplanejador (PT-BR)
Um esboço de um padrão de IA para videogames feito em C#, projetado para organizar transições lógicas de uma máquina de estados comum a partir de uma lógica de mais fácil compreensão. Essa implementação funciona com duas maquinas de estados, um monitorador local e um monitorador global (opcional).

Os comportamentos são criados a partir de uma sequência predefinida de estados - uma lista que é iterada a partir de condições lógicas - 
não ocorrendo planejamento de verdade, sendo assim basicamente só um roteiro ou uma rotina feito pelo programador que a IA deve seguir e parecer que está elaborando um plano. Daí vem o nome "Pseudo-planner" ou "Pseudo-planejador" em inglês.

Inspirado nos elementos de lógica [PAOM](https://citeseerx.ist.psu.edu/document?repid=rep1&type=pdf&doi=0c35d00a015c93bac68475e8e1283b02701ff46b)<sup>(Planejador de Ações Orientadas a Metas, ou Goal Oriented Action Planner, GOAP em inglês)</sup> e [Árvores de comportamento](https://en-m-wikipedia-org.translate.goog/wiki/Behavior_tree_(artificial_intelligence,_robotics_and_control)?_x_tr_sl=auto&_x_tr_tl=pt&_x_tr_hl=pt-BR&_x_tr_pto=wapp), mas utilizando a lógica simples de uma máquina de estados.


### Resumo dos arquivos
1. PseudoPlanner.cs
    O motor para os planos. Faz com que os scripts sejam atualizados durante a execução e possui alguns métodos para lidar com transições de planos, além de um método auxiliar para lógica atrasada.
2. PseudoPlannerBasePlan.cs
    O script de modelo do qual os planos derivam.
3. Flags.cs
    Os métodos booleanos que o script verificará para avaliar as iterações da lista de estados.
5. PlanFlank.cs
    Um exemplo concreto de um plano.

*@2025 - Projeto pessoal. Elaborado por mim.*

