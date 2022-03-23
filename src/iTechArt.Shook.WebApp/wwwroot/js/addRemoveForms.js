document.addEventListener('DOMContentLoaded', () => {

    const questionContainer = document.querySelector('.questionsContainer'),
        surveyForm = document.querySelector('form#surveyForm');

    document.querySelector('#addRow').addEventListener('click', addQuestionForm);

    document.querySelectorAll('.deleteButton').forEach(button => {
        button.addEventListener('click', function () {
            const questionId = parseInt(button.closest('fieldset').getAttribute('id'), 10);
            button.closest('fieldset').remove();
            --counter;
            refreshQuestionsList(Array.from(surveyForm.querySelectorAll('fieldset')), questionId);
        });
    });


    let counter = surveyForm.querySelectorAll('fieldset').length;
    refreshQuestionsList(Array.from(surveyForm.querySelectorAll('fieldset')), 0);

    function addQuestionForm() {
        const clone = document.querySelector('#template').content.cloneNode(true),
            questionFieldset = clone.querySelector('fieldset'),
            questionId = clone.querySelector('#questionId');
            questionTitle = clone.querySelector('.questionTitle');
        
        setAttributeToObject(questionFieldset, 'id', `${counter}`);
        setAttributeToObject(questionId, 'name', `Questions[${counter}].Title`);
        setAttributeToObject(questionTitle, 'name', `Questions[${counter}].Title`);
        questionFieldset.querySelector('#counter').textContent = `${counter + 1}`;

        ++counter;

        questionFieldset
            .querySelector('.deleteButton')
            .addEventListener('click', function () {
                const questionId = parseInt(questionFieldset.getAttribute('id'), 10);
                questionFieldset.remove();
                --counter;
                refreshQuestionsList(Array.from(surveyForm.querySelectorAll('fieldset')), questionId);
            });

        questionContainer.appendChild(clone);
    }

    function setAttributeToObject(obj, attr, val) {
        obj.setAttribute(attr, val);
    }

    function refreshQuestionsList(arrayObj, deleteItemIndex) {
        
        arrayObj.forEach((fieldset, index) => {
            const id = fieldset.querySelector('#questionId'),
                title = fieldset.querySelector('.questionTitle'),
                counter = fieldset.querySelector('#counter');

            counter.textContent = `${index + 1}`;
            setAttributeToObject(fieldset, 'id', `${index}`);
            setAttributeToObject(id, 'name', `Questions[${index}].Id`);
            setAttributeToObject(title, 'name', `Questions[${index}].Title`);
        })
    }
});