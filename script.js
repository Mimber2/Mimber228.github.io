let currentInput = '0';
let operation = null;
let previousInput = null;

function updateDisplay() {
  document.getElementById('display').value = currentInput;
}

function appendToDisplay(number) {
  if (currentInput === '0' && number !== '.') {
    currentInput = number;
  } else {
    currentInput += number;
  }
  updateDisplay();
}

function setOperation(op) {
  operation = op;
  previousInput = parseFloat(currentInput);
  currentInput = '0';
}

function calculate() {
  if (!operation || !previousInput) return;
  
  const current = parseFloat(currentInput);
  let result;
  
  switch (operation) {
    case '+':
      result = previousInput + current;
      break;
    case '-':
      result = previousInput - current;
      break;
    case '*':
      result = previousInput * current;
      break;
    case '/':
      result = previousInput / current;
      break;
  }
  
  currentInput = result.toString();
  operation = null;
  previousInput = null;
  updateDisplay();
}

function clearDisplay() {
  currentInput = '0';
  operation = null;
  previousInput = null;
  updateDisplay();
}

// Инициализация
updateDisplay();
