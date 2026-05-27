const actionBtn = document.getElementById('actionButton')
const actionInput = document.getElementById('actionInput')
const turnInput = document.getElementById('turnInput')
const activeScoreSheet = document.getElementById('activeTable')

const action = JSON.parse(actionInput.value)

// Is needed to avoid auto roll in loaded game
if(action.Choice === 'none'){
    action.Choice = 'Roll'
    actionInput.value = JSON.stringify(action)
}

const rows = Array.from(activeScoreSheet.querySelectorAll('tbody tr'))
const inactiveIndex = [6, 7, 15, 16]
rows.forEach((row, index)=>{
    if(!inactiveIndex.includes(index)){
        row.addEventListener('click', ()=>{
            if(!action.Rolls.length)return false

            // Player changes his mind and wants to Roll again instead of ending his turn
            if(action.Rolls.length < 3 && action.Score === index.toString()){
                action.Choice = 'Roll'
                action.Score = 'none'
                actionInput.value = JSON.stringify(action)
                actionBtn.innerHTML = 'Würfeln'
                row.classList.remove('marked-row')
                return
            }

            action.Choice = 'Score'
            action.Score = index.toString()
            actionInput.value = JSON.stringify(action)
            actionBtn.innerHTML = 'Zug beenden'
            actionBtn.disabled = false
            rows.forEach((row)=>{row.classList.remove('marked-row')})
            row.classList.add('marked-row')

        })
    }
})

if(action.Rolls.length > 2){
    actionBtn.disabled = true
    actionBtn.innerHTML = 'Zug beenden'
}

if(action.Rolls.length){
    const rollDiv = document.getElementById('rollDiv')
    rollDiv.className = 'roll-div'
    for(let i=0; i<rollDiv.children.length; i+=1){
        rollDiv.children[i].addEventListener('click', ()=>{
            const keepIndex = action.Keep.findIndex((keep)=>{
                return keep === i
            })

            if(keepIndex === -1){
                action.Keep.push(i)
                rollDiv.children[i].style.color = 'green'
            }else{
                action.Keep.splice(keepIndex, 1)
                rollDiv.children[i].style.color = 'black'
            }
            actionInput.value = JSON.stringify(action)
        })
    }
}
