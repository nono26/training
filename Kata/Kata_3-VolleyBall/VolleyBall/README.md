# VolleyBall
The program takes 2 inputs:
- p1 = The probability that Team 1 wins the point when Team 1 is serving
- p2 = The probability that Team 2 wins the point when Team 2 is serving

The rules:
1. To win the match, a team must win 3 sets.
2. To win a set, a team must win at least 25 points with a 2-points margin minimum, e.g. 25-17, 24-26, 28-26.
3. Exception to rule #2: If both teams are tied at 2 sets, the fifth and last set ends in 15 points, again with a 2-points margin minimum.
4. Team 1 starts serving in set 1, Team 2 starts serving in set 2, Team 1 starts serving in set 3, and so on.
5. The team that won the previous point serves for the next point, unless the set is just starting.
6. The team that won the point scores a point, regardless of whether it was already serving or not.

The output of the program is the list of scores, from the beginning to the end of the game.

Example, if team 1 wins all points:

```rb
VolleyballSimulator.run(1.0, 0.0) == [
  "0-0", # Game starts
  "1-0", # Team 1 wins 1st point
  "2-0",
  # ...
  "25-0",
  "25-0 1-0",
  "25-0 2-0",
  # ...
  "25-0 25-0",
  "25-0 25-0 1-0",
  "25-0 25-0 2-0",
  # ...
  "25-0 25-0 25-0" # Game ends
]
```


Framework : .net 6

how to run it:

On the root folder

Change the team probabilites from the appsettings.json file

Probabilities are defined from 0 to 100 

dotnet build && dotnet run --project VolleyBall/VolleyBall.csproj



enjoy!
