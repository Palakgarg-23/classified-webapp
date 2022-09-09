import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';
import { ConfigService } from '../config/config.service';
import { AuthResponse } from '../model/authResponse';
import { User } from '../model/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  constructor(private configService: ConfigService,private router:Router) { }

  //user object to save user form details
  user: User = { username:0, password: "" }
  authResponse:AuthResponse=new AuthResponse("","")

  //reactive form for login
  userForm: FormGroup = new FormGroup({})

  //to display errors
  formError = ""

  ngOnInit(): void {

    //initialize the form
    this.userForm = new FormGroup({
      username: new FormControl(this.user.username, [
        Validators.required,
        Validators.minLength(3)
      ]),
      password: new FormControl(this.user.password, [
        Validators.required,
      ])
    })
  }

  get username() { return this.userForm.get('username') }
  get password() { return this.userForm.get('password') }

  //on submitting the form
  onSubmit() {
    
    let userDetails = { "EmployeeId": this.userForm.value.username, "Password": this.userForm.value.password}
    
    //retrive the data from the authmicroservice
    this.configService.getUserToken(userDetails).subscribe((data:AuthResponse)=>{
      this.authResponse=data
      //save the token in local storage
      let a=this.authResponse.authToken
      let b=userDetails.EmployeeId
      localStorage.setItem("token",a)
      
      //save the user id in local storage
      localStorage.setItem("userId",b)

      //navigate to the main page of the user
      this.router.navigate(['main'])
    },
    error =>{
      this.formError = "Credentials are incorrect"
      console.log(error)
    });

  }
}
