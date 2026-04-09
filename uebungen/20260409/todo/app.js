const taskBtn = document.getElementById('saveTaskBtn')
const taskInput = document.getElementById('taskInput')
const deadLineInput = document.getElementById('deadLineInput')
const todoList = document.getElementById('todoList')
const loadBtn = document.getElementById('loadTodoListBtn')

const liste = []

if(!liste.length){
    let placeholderItem = document.createElement('li')
    placeholderItem.innerHTML = 'Keine Aufgaben vorhanden'
    todoList.appendChild(placeholderItem)
}

function saveTask(task){
    localStorage.setItem('task', task)
}

function clearTodoList(){
    while(todoList.firstChild){
        todoList.removeChild(todoList.firstChild)
    }
}

loadBtn.addEventListener('click', ()=>{
    const taskString = localStorage.getItem('task')
    const taskArray = JSON.parse(taskString)

    clearTodoList()
    
    for(let i=0; i<taskArray.length; i+=1){
        const listItem = document.createElement('li')
        listItem.innerHTML = taskArray[i]
        todoList.appendChild(listItem)
    }

})

taskBtn.addEventListener('click', ()=>{
    clearTodoList()
    const todo = taskInput.value
    const deadLine = deadLineInput.value
    const listString = `${todo} Deadline: ${deadLine}Uhr`
    liste.push(listString)

    liste.forEach((item)=>{
        const listItem = document.createElement('li')
        listItem.innerHTML = item 
        todoList.appendChild(listItem)
    })
    const saveString = JSON.stringify(liste)

    saveTask(saveString)
})
