import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserLoginModel } from 'src/core/services/models/user-login-model';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent implements OnInit {
  public taskCreateForm: FormGroup = new FormGroup({});
  public emailControl: FormControl;
  public passwordControl: FormControl;

  public user: UserLoginModel ={};
  constructor() {
    this.emailControl = new FormControl(this.user.email, [
      Validators.required,
      Validators.minLength(2),
      Validators.maxLength(80),
    ]);
    this.passwordControl = new FormControl(this.user.password, [
      Validators.required,
      Validators.minLength(2),
      Validators.maxLength(80),
    ]);
  }

  public test(): void {
    console.log(this.taskCreateForm.get('emailControl')?.value);
    console.log(this.taskCreateForm.get('passwordControl')?.value);

    this.user = {
      email: this.taskCreateForm.get('emailControl')?.value,
      password: this.taskCreateForm.get('passwordControl')?.value,
    }
    console.log(this.user);
  }
  ngOnInit(): void {
    this.taskCreateForm = new FormGroup({
      emailControl: this.emailControl,
      passwordControl: this.passwordControl,
    });
  }
}
