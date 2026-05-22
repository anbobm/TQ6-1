const playerSelect = document.getElementById('playerSelect')
const addPlayerBtn = document.getElementById('addPlayerBtn')
const playerList = document.getElementById('playerList')
const gameSettingsInput = document.getElementById('gameSettingsInput')
const startGameBtn = document.getElementById('startGameBtn')

const playerIDs = []

playerSelect.addEventListener('change', ()=>{
    if(playerIDs.includes(playerSelect.value)){
        addPlayerBtn.disabled = true
    }else if(playerSelect.value === '0'){
        addPlayerBtn.disabled = true
    }else{
        addPlayerBtn.disabled = false
    }
})

addPlayerBtn.addEventListener('click', ()=>{
    const selectedOption = playerSelect.options[playerSelect.selectedIndex]
    const playerName = selectedOption.getAttribute('data-name');
    const player = document.createElement('li')
    player.innerHTML = playerName
    playerIDs.push(playerSelect.value)
    gameSettingsInput.value = ''
    playerIDs.forEach((playerID, index)=>{
        if(index < playerIDs.length-1){
            gameSettingsInput.value += `${playerID}-`
        }else{
            gameSettingsInput.value += `${playerID}`
        }
    })
    if(playerIDs.length >= 2){
        startGameBtn.disabled = false
    }else{
        startGameBtn.disabled = true
    } 
    playerList.appendChild(player)
})
