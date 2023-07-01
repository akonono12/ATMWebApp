import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 public inputValue:string = '';
 @Output() login: EventEmitter<string> = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }
  public onLogin(){
    if(!this.inputValue){
      alert("Empty text box.Please enter a valid input!")
      return;
    }
    this.login.emit(this.inputValue);
    this.inputValue = '';
  }

}
