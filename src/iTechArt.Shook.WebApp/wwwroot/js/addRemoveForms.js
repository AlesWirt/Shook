'use strict';

const container = document.querySelector('#questionContainer');
const template = document.querySelector('#template');
const addQuestionButton = document.querySelector('#addRow');
const deleteQuestionButtons = document.querySelectorAll("#deleteQuestion");

addQuestionButton.addEventListener('click', () => {
    const clone = template.content.cloneNode(true);

    container.appendChild(clone);
    document.querySelectorAll("#deleteQuestion").forEach((btn, i) => {
        btn.addEventListener('click', () => {
            btn.parentElement.parentElement.remove();
        });
    });
});