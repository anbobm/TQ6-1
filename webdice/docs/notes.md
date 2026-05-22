            <section class="game-grid">
                <section class="player-grid">
                    @foreach(var player in Model.GameController.Players){
                        <table>
                            <caption>@player.Name</caption>
                            @foreach(var upperScore in player.ScoreSheet.UpperPart){
                                <tr id="@($"{player.Id}score{upperScore.Id}")">
                                    <td>@upperScore.Name</td>
                                    <td>@upperScore.Points</td>
                                </tr>
                            }
                            <tr>
                                <td>Punkte Oben</td>
                                <td>@player.ScoreSheet.UpperScore</td>
                            </tr>
                            <tr>
                                <td>Bonus (&gt; 63)</td>
                                @if(player.ScoreSheet.UpperScore >= 63){
                                    <td>35</td>
                                }else{
                                    <td>0</td>
                                }
                            </tr>
                            <tr>
                                <td>Oben Gesamt</td>
                                <td>@player.ScoreSheet.UpperScoreTotal()</td>
                            </tr>
                            @foreach(var lowerScore in player.ScoreSheet.LowerPart){
                                <tr>
                                    <td>@lowerScore.Name</td>
                                    <td>@lowerScore.Points</td>
                                </tr>
                            }
                            <tr>
                                <td>Punkte Unten</td>
                                <td>@player.ScoreSheet.LowerScore</td>
                            </tr>
                            <tr>
                                <td>Punkte Gesamt</td>
                                <td>@player.ScoreSheet.ScoreSum()</td>
                            </tr>
                        </table>
                    }
                </section>
                <section class="dice-grid">
                    <h1>Am Zug: @Model.GameController.CurrentTurn().Player.Name</h1>
                    <form method="post">
                        @Html.AntiForgeryToken()
                        <input id="actionInput" name="actionInput">
                        <button id="actionBtn">Würfeln!</button>
                    </form>
                    <input id="turnInput" data-json="@Model.GameController.CurrentTurnToJson()">
                </section>
            </section>
