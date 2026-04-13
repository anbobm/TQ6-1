/*
const name = 'Timo Röhle'
localStorage.setItem('benutzername', name)
localStorage.setItem('alter', 42)

console.log(`${localStorage.getItem('benutzername')}, ${localStorage.getItem('alter')}`)

// Nicht vorhanden
console.log(localStorage.getItem('blubla'))
localStorage.removeItem('alter')
console.log(localStorage.getItem('alter'))
*/

/*
// Aufgabe 2:
let einstellungen = {
    theme: 'dunkel',
    sprache: 'de',
    schriftgroesse: 14
}

localStorage.setItem('einstellungen', JSON.stringify(einstellungen))

einstellungen = JSON.parse(localStorage.getItem('einstellungen'))
console.log(`Theme: ${einstellungen.theme} Schriftgroesse: ${einstellungen.schriftgroesse}`)

const leeresArray = []
leeresArray.push('String1')
leeresArray.push('String2')
leeresArray.push('String3')

localStorage.setItem('befuelltesArray', JSON.stringify(leeresArray))

const befuelltesArray = JSON.parse(localStorage.getItem('befuelltesArray'))
console.log(befuelltesArray)
*/

/*
const KEY = 'todos'

function todosLaden(){
    const todos = localStorage.getItem(KEY)
    if(!todos) return []
    return JSON.parse(todos)
}

function todosSpeichern(todos){
    localStorage.setItem(KEY, JSON.stringify(todos))
}

todosSpeichern(['Einkaufen', 'Sport', 'Lernen'])
console.log(todosLaden())

localStorage.clear()
console.log(todosLaden())
*/

const KEY = 'todos'
function todosLaden(){
    const todos = localStorage.getItem(KEY)
    if(!todos) return []
    return JSON.parse(todos)
}

function todosSpeichern(todos){
    localStorage.setItem(KEY, JSON.stringify(todos))
}

function todoErstellen(text){
    const task = {
        id: crypto.randomUUID(),
        text: text,
        erledigt: false,
        erstellt: Date.now()
    }
    return task
}

function todoHinzufuegen(text){
    const todos = todosLaden()
    todos.push(todoErstellen(text))
    todosSpeichern(todos)
}

function todoUmschalten(id){
    const todos = todosLaden()
    const todoIndex = todos.findIndex((task)=>{
        return task.id === id 
    })
    if(todoIndex === -1)return false
    todos[todoIndex].erledigt = !todos[todoIndex].erledigt
    todosSpeichern(todos)
}

function todoLoeschen(id){
    const newTodoList = todos.filter((task)=>{
        return taks.id !== id
    })
    todosSpeichern(newTodoList)
}

todoHinzufuegen('Neue Aufgabe')
const myTodos = todosLaden()
console.log(myTodos)
todoUmschalten(myTodos[0].id)
console.log(new Date(myTodos[0].erstellt).toLocaleString('de-DE'))
console.log(myTodos)

console.log(new Date().toLocaleString('de-DE'))
