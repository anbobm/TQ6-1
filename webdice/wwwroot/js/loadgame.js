const gameSelect = document.getElementById('gameSelect')
const actionInput = document.getElementById('actionInput')

const action = JSON.parse(actionInput.value)
gameSelect.addEventListener('change', ()=>{
    if(gameSelect.value === '0')return false
    action.GameId = parseInt(gameSelect.value)
    actionInput.value = JSON.stringify(action)
})
