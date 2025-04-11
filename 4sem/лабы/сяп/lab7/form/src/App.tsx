import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route, Link as RouterLink } from "react-router-dom";
import "./App.css";

const emails = Array<string>();

const App = () =>
   {
  return (
    <Router>
      <div className="container">
        <Routes>
          <Route path="/" element= {<RegisterPage/>}/>
          <Route path="/sign-up" element={<RegisterPage />} />
          <Route path="/sign-in" element={<LoginPage />} />
          <Route path="/reset-password" element={<ResetPasswordPage />} />
        </Routes>
      </div>
    </Router>
  );
};

const LoginPage = () =>
   {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  
  return (
    <div className="main">
      <h1>Вход</h1>
      <div className="inputContainer">
        <Field text="введите e-mail" onChange={(e) => setEmail(e.target.value)} />
        <Field text="пароль" onChange={(e) => setPassword(e.target.value)} />
      </div>
      <Button
        title="войти"
        onClick={() => {
          if (ValidateEmail(email,false) && ValidatePassword(password)) {
            alert("успех авторизации");
          } else {
            alert("неверный логин или пароль");
          }
        }}
      />
      <Link placeholder="зарегистрироваться" linkTo="/sign-up" />
      <Link placeholder="забыл пароль" linkTo="/reset-password" />
    </div>
  );
};

const ResetPasswordPage = () => 
  {
  const [email, changeEmail] = useState("");

  

  return (
    <div className="main">
      <h1>Восстановить пароль</h1>
      <div className="inputContainer">
        <Field text="e-mail" onChange={(e) => changeEmail(e.target.value)} />
      </div>
      <Button
        title="восстановить пароль"
        onClick={() => {
          if (ValidateEmail(email,false) && emails.includes(email)) {
            alert("ваш новый пароль: Дэб123_45");
          } else {
            alert("неверная почта или вы не были зарегистрированы");
          }
        }}
      />
    </div>
  );
};

const RegisterPage = () =>
   {
  const [name, changeName] = useState("");
  const [email, changeEmail] = useState("");
  const [password, changePassword] = useState("");
  const [password2,changePassword2] = useState("");
  

  return (
    <div className="main">
      <h1>Регистрация</h1>
      <div className="inputContainer">
        <Field text="имя" onChange={(e) => changeName(e.target.value)} />
        <Field text="email" onChange={(e) => changeEmail(e.target.value)} />
        <Field text="пароль" onChange={(e) => changePassword(e.target.value)} />
        <Field text="подтвердите пароль" onChange={(e) => changePassword2(e.target.value)} />
      </div>
      <Button
        title="регистрация"
        onClick={() => {
          if (ValidateEmail(email,true) && ValidateName(name) && ValidatePassword(password) && (password === password2)) {
            alert("успех регистрации");
            emails.push(email);
          }
        }}
      />
      <Link placeholder="войти в аккаунт" linkTo="/sign-in" />
    </div>
  );
};

const Button = ({ title, onClick }: { title: string; onClick: () => void }) =>
(
  <button onClick={onClick}>{title}</button>
);

const Field = ({ text, onChange }: { text: string; onChange: (e: React.ChangeEvent<HTMLInputElement>) => void }) =>
(
  <input type="text" placeholder={text} onChange={onChange} />
);

const Link = ({ placeholder, linkTo }: { placeholder: string; linkTo: string }) => 
(
  <RouterLink to={linkTo}>{placeholder}</RouterLink>
);

const ValidateEmail = (email:string,register:boolean) =>
  {
    if(!email)
    {
      alert("адрес не должен быть пустым")
      return false;
    }
    if(/\s/.test(email)) // whitespace test
    {
      alert("почта не должна содержать пробелы")
      return false
    }
    const emailregex = /[^@]+@[a-zA-Z]{2,10}\.[a-zA-Z]{2,3}$/
    if(!emailregex.test(email))
    {
      alert("введен неверный адрес")
      return false
    }
    if(register === true)
    {
      if(emails.includes(email))
        {
          alert("этот почтовый адрес уже занят")
          return false;
        }
    }
   
    return true;
  }
const ValidatePassword = (password:string) =>
{
  if(!password)
  {
    alert("пароль не может быть пустым")
    return false;
  }
  if(password.length<8)
  {
    alert("пароль должен быть минимум 8 символов")
    return false;
  }
  if(!(/[A-Z]/.test(password) && /[a-z]/.test(password) && /\d/.test(password) ))
  {
    alert("пароль должен содкержать 1 заглавную, 1 строчную буквы и 1 цифру")
    return false;
  }
  if(/\s/.test(password))
  {
    alert("пароль не должен содержать пробелы")
    return false;
  }
  return true
}
const ValidateName = (name:string) =>
{
  if(!name)
  {
    alert("имя не должно быть пустым")
    return false;
  }
  if(name.length<2)
  {
    alert("имя должно быть минимум 2 символа")
    return false;
  }
  if(name.length > 50 )
  {
    alert("имя должно быть менее 50 символов")
    return false;
  }
  const nameRegex = /^[A-Za-zА-Яа-я\s]+$/;
  if(!nameRegex.test(name))
  {
    alert("имя должно содержать только буквы ")
    return false;
  }
  return true
}
export default App;