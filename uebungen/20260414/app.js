class Transaction {
    constructor(
        id,
        betrag,
        datum,
        beschreibung,
        typ,
        kategorie
    ){
        this.id = id
        this.betrag = betrag
        this.datum = datum
        this.beschreibung = beschreibung
        this.typ = typ
        this.kategorie = kategorie
    }
}

class UI {
    constructor(){
        this.inputs = {
            betrag: document.getElementById('betragInput'),
            datum: document.getElementById('dateInput'),
            beschreibung: document.getElementById('descriptionInput'),
            einkommenSelect: document.getElementById('incomeSelect'),
            ausgabenSelect: document.getElementById('expenseSelect'),
            typ: document.querySelectorAll('input[name="typeInput"]')
        }
        this.btns = {
            save: document.getElementById('saveBtn')
        }

        this.init()
    }

    validateInputs(){
        let validInputs = true
        let betrag = parseFloat(this.inputs.betrag.value)
        if(!betrag || betrag < 0){
            this.inputs.betrag.classList.add('alert')
            validInputs = false
        }else{
            this.inputs.betrag.classList.remove('alert')

        }

        if(this.inputs.beschreibung.value === ''){
            this.inputs.beschreibung.classList.add('alert')
            validInputs = false
        }else{
            this.inputs.beschreibung.classList.remove('alert')

        }
        const categoryField = document.getElementById('categoryField')
        console.log(this.inputs.einkommenSelect.value)
        if(this.getTyp() === 'einnahme' && this.inputs.einkommenSelect.value === '0'){
            categoryField.style.border = "2px solid red"
            validInputs = false
        }

        if(this.getTyp() === 'einnahme' && this.inputs.einkommenSelect.value !== '0'){
            categoryField.style.border = "2px solid green"
        }
        
        if(this.getTyp() === 'ausgabe' && this.inputs.ausgabenSelect.value === '0'){
            categoryField.style.border = "2px solid red"
            validInputs = false
        }

        if(this.getTyp() === 'ausgabe' && this.inputs.ausgabenSelect.value !== '0'){
            categoryField.style.border = "2px solid green"
        }
        return validInputs
    }

    getTyp(){
        const typ = document.querySelector('input[name="typeInput"]:checked')
        return typ.value
    }

    getCategory(){
        const typ = this.getTyp()
        let category = ''
        if(typ === 'einahmen'){
            category = this.inputs.einkommenSelect.value
        }
        if(typ === 'ausgaben'){
            category = this.inputs.ausgabenSelect.value
        }
        console.log(category)
        return category

    }

    init(){
        this.btns.save.addEventListener('click', ()=>{
            let validInputs = this.validateInputs()
            if(!validInputs)return false

            const transaction = new Transaction(
                crypto.randomUUID(),
                parseFloat(this.inputs.betrag.value).toFixed(2),
                this.inputs.datum.value,
                this.inputs.beschreibung.value,
                this.getTyp(),
                this.getCategory()
            )
            app.addTransaction(transaction)
            console.log(transaction) 
        })
    }
}

class App {
    constructor(){
        this.ui = new UI()
        this.transactions = []
        this.init()
    }

    init(){
        const dateTimeArr = new Date(Date.now()).toISOString().split('T')
        this.ui.inputs.datum.value = dateTimeArr[0]
        this.loadTransactions
    }

    addTransaction(transaction){
        this.transactions.push(transaction)
    }

    loadTransactions(){
        const transactionString = localStorage.getItem('transactions')
        if(!transactionString){
            this.transactions = []
        }else{
            this.transactions = JSON.parse(transactionString)
        }
        return this.transactions
    }

    saveTransactions(){
        localStorage.setItem('transactions', JSON.stringify(this.transactions))
    }
    
}

const app = new App()
