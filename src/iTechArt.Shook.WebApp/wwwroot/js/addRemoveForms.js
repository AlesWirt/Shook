document.addEventListener('DOMContentLoaded', () => {

    const questionContainer = document.querySelector('.questionsContainer'),
        surveyForm = document.querySelector('form#surveyForm');
    questionsList = Array.from(surveyForm.querySelectorAll('fieldset'));
    document.querySelector('#addRow').addEventListener('click', addQuestionForm);

    let counter = 0;

    function addQuestionForm() {
        const clone = document.querySelector('#template').content.cloneNode(true),
            questionFieldset = clone.querySelector('fieldset'),
            questionTitle = clone.querySelector('.questionTitle');
        
        setAttributeToObject(questionFieldset, 'id', `${counter}`);
        setAttributeToObject(questionTitle, 'name', `Questions[${counter}].Title`);
        questionFieldset.querySelector('#counter').textContent = `${counter + 1}`;

        ++counter;

        questionFieldset
            .querySelector('.deleteButton')
            .addEventListener('click', function () {
                const questionId = parseInt(questionFieldset.getAttribute('id'), 10);
                questionFieldset.remove();
                --counter;
                console.log(`Question with index ${questionId} was deleted!`);
                refreshQuestionsList(Array.from(surveyForm.querySelectorAll('fieldset')), questionId);
            });

        questionContainer.appendChild(clone);
        let lastIndex = surveyForm.querySelectorAll('fieldset').length - 1;
        const lastFieldset = surveyForm.querySelectorAll('fieldset')[lastIndex];
        questionsList.push(lastFieldset);
        console.log('New question added:');
        showItems(questionsList);
    }

    function setAttributeToObject(obj, attr, val) {
        obj.setAttribute(attr, val);
    }

    function refreshQuestionsList(arrayObj, deleteItemIndex) {
        //for (let i = startIndex; i < arrayObj.length; i++) {
        //    const fieldset = arrayObj[i].querySelector('fieldset'),
        //        title = arrayObj[i].querySelector('.questionTitle'),
        //        counter = arrayObj[i].querySelector('#counter');
            
        //    counter.textContent = `${i + 1}`;
        //    setAttributeToObject(fieldset, 'id', `${i}`);
        //    setAttributeToObject(title, 'name', `Questions[${i}].Title`);
        //}
        console.log(arrayObj);
        
        const sortedArr = arrayObj.sort((item1, item2) => {
            const fieldsetCounter1 = item1.querySelector('#counter');
            const fieldsetCounter2 = item2.querySelector('#counter');

            return fieldsetCounter1 - fieldsetCounter2;
        });

        sortedArr.forEach((item, index) => {
            title = item.querySelector('.questionTitle'),
            counter = item.querySelector('#counter');

            counter.textContent = `${index + 1}`;
            setAttributeToObject(item, 'id', `${index}`);
            setAttributeToObject(title, 'name', `Questions[${index}].Title`);
        })
    }

    function showItems(...arrayObj) {
        arrayObj.forEach(element => console.log(element));
    }
});