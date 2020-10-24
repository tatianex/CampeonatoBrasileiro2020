# CampeonatoBrasileiro2020

## Brasileirão 2020 A

* R1. As funcionalidades do sistema deverão ser protegidas, apenas os usuários permitidos poderão acessá-las.

* R2. Cada usuário terá um único perfil, sendo ele o perfil “Torcedor” ou “CBF”. O perfil Torcedor fará operações comuns, enquanto o perfil CBF terá todas as permissões do Torcedor, e mais aquelas que são de função administrativa.

* R3. Os times que farão parte do campeonato devem ser cadastrados, após o cadastro não será possível modificar os clubes participantes, a quantidade de clubes cadastrados deve ser maior que 7. (CBF)

* R4. O campeonato deve gerar automaticamente os confrontos entre os times.

Para criar o método que gera os confrontos utilizamos as orientações da seguinte pesquisa:
- [Wikipedia](https://pt.wikipedia.org/wiki/Competi%C3%A7%C3%B5es_de_todos_contra_todos)
Uma competição de "todos contra todos" também conhecida como sistema de pontos corridos, onde na nossa aplicação funciona no esquema de turno único.

* R5. Após os confrontos serem gerados, será necessário que o resultado dos jogos sejam informados, rodada por rodada. (CBF)

* R6. Cada time pode remover ou adicionar jogadores durante o decorrer do campeonato, tendo um limite mínimo e máximo de, respectivamente, 16 e 32 jogadores. (CBF)

* R7. O campeonato deve apresentar a tabela atualizada da pontuação dos clubes, contendo os seguintes dados: Pontuação; Partidas disputadas; Vitórias; Empates; Derrotas; Saldo de gols; Gols pró; Gols contra; Porcentagem de aproveitamento (Torcedor)

* R8. O campeonato deve apresentar a relações dos artilheiros. (Torcedor)

* R9. O campeonato deve fornecer os resultados de cada rodada (Torcedor)

* R10. O campeonato deve apresentar a relação dos times rebaixados (4 últimos) e classificados para a libertadores (4 primeiros) (Torcedor)