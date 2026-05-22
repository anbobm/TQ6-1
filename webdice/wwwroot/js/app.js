const actionBtn = document.getElementById('actionBtn')
const actionInput = document.getElementById('actionInput')
const turnInput = document.getElementById('turnInput')
const activeScoreSheet = document.getElementById('activeTable')

console.log(activeScoreSheet.children[1].children)

const rows = Array.from(activeScoreSheet.querySelectorAll('tbody tr'))
rows.forEach((row, index)=>{
    row.addEventListener('click', ()=>{
        console.log(index)
    })
})

const action = JSON.parse(actionInput.value)

if(action.Rolls.length){
    const rollDiv = document.getElementById('rollDiv')
    for(let i=0; i<rollDiv.children.length; i+=1){
        rollDiv.children[i].addEventListener('click', ()=>{
            const keepIndex = action.Keep.findIndex((keep)=>{
                return keep === i
            })

            if(keepIndex === -1){
                action.Keep.push(i)
                rollDiv.children[i].style.background = 'red'
            }else{
                action.Keep.splice(keepIndex, 1)
                rollDiv.children[i].style.background = 'white'
            }
            console.log(i)
            actionInput.value = JSON.stringify(action)
        })
    }
    console.log(rollDiv)
}
