import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent implements OnInit {
  public taskCreateForm: FormGroup = new FormGroup({});
  public summaryControl: FormControl;

  public inputSearch = '';
  constructor() {
    this.summaryControl = new FormControl(this.inputSearch, [
      Validators.required,
      Validators.minLength(2),
      Validators.maxLength(80),
    ]);
  }

  public test(): void {
 
    console.log(this.inputSearch);
  }
  ngOnInit(): void {}
}
