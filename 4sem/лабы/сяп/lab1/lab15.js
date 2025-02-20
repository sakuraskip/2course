function validateform()
{
    console.log("alo");

    document.querySelectorAll('.error').forEach(error_elem=>error_elem.innerHTML = '');
    
    var nameregex = /[a-zA-Zа-яА-Я]+$/;

    let haserror = false;
    let name = document.getElementById('name').value;
    let surname = document.getElementById('surname').value;

    if(!nameregex.test(name) || name.length >20)
    {
        haserror = true;
        document.getElementById('name_err').innerText = 'имя содержит только буквы русского и англ. алфавита и не превышает 20 символов'
    }
    if(!nameregex.test(surname) || surname.length >20)
    {
        haserror = true;
        document.getElementById('surname_err').innerText = 'фамилия содержит только буквы русского и англ. алфавита и не превышает 20 символов'
    }
    var emailregex = /[^@]+@[a-zA-Z]{2,5}\.[a-zA-Z]{2,3}$/
    let email = document.getElementById('email').value;
    if(!emailregex.test(email))
    {
        haserror = true;
        document.getElementById('email_err').innerText = 'ошибка в записи почты'
    }
    var phoneregex = /^\(0\d{2}\)\d{3}-\d{2}-\d{2}$/
    let phone = document.getElementById('phone').value
    if(!phoneregex.test(phone))
    {
        haserror = true;
        document.getElementById('phone_err').innerText = 'ошибка в записи телефона'
    }
    let textarea = document.getElementById('about').value;
    if(textarea.length>250)
    {
         haserror = true;
        document.getElementById('textarea_err').innerText = 'длина не может превышать 250'
    }
    let city = document.getElementById('city').value;
    console.log(city);
    let bstu = document.getElementById('bstu');
    console.log(bstu.checked);

    let course = document.querySelector('input[name="course"]:checked')
    console.log(course.value);

    if(!course)
    {
        haserror = true;
        document.getElementById('course_err').innerText = 'выберите курс';

    }
    else if((course.value!==3) || (bstu.checked === false) || (city!=='Минск'))
    {
        if(!confirm("вы уверены в выборе курса, университета и города??"))
        {
            haserror = true;
            return;
        }
    }

    if(!haserror)
    {
        alert("форма отправлена");
    }
    
    
}
