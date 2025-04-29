# Pseudoplanejador (PT-BR)
Um esboço de um padrão de IA para videogames feito em C#, projetado para organizar transições lógicas de uma máquina de estados comum a partir de uma lógica de mais fácil compreensão. 

Os comportamentos são criados a partir de uma sequência lógica predefinida de estados - uma lista que é iterada a partir de condições lógicas - 
não ocorrendo planejamento de verdade, sendo assim basicamente só um roteiro ou uma rotina feito pelo programador que a IA deve seguir e parecer que está elaborando um plano. Daí vem o nome "Pseudo-planner" ou "Pseudo-planejador" em inglês.

Inspirado nos elementos de lógica [PAOM](https://www.ai.rug.nl/gwenniger/Finished_Projects/GOAP-Report.pdf)<sup>(Planejador de Ações Orientadas a Metas, ou Goal Oriented Action Planner, GOAP em inglês)</sup> e [Árvores de comportamento](https://en-m-wikipedia-org.translate.goog/wiki/Behavior_tree_(artificial_intelligence,_robotics_and_control)?_x_tr_sl=auto&_x_tr_tl=pt&_x_tr_hl=pt-BR&_x_tr_pto=wapp), mas utilizando a lógica simples de uma máquina de estados.

# Pseudoplanner (EN)
An sketch of an AI design pattern for videogames written in C#, designed to make organizing state machine logic transitions easier.

Behaviors are created from a predefined logical sequence of states - a list that is iterated based on logical conditions - so there's no real planning going on. It's pretty much a script or routine that the bot follows, making it look like it's rationalizing plans during gameplay. Hence the name "Pseudo-planner".

Inspired by the elements of GOAP logic and Behavior Trees, but using a state machine as a base.
