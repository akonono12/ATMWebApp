import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Account } from '../../models/account';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
 @Input() account:Account = new Account();
 public amountValue:number = 0;
 @Output() withdraw: EventEmitter<{amount: number, id: string}> = new EventEmitter();
 @Output() deposit: EventEmitter<{amount: number, id: string}> = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  public onWithDraw(){
    if(this.account.balance - this.amountValue < 0){
      alert("The withdrawal amount exceeds.Please check your available balance!")
      this.amountValue = 0;
      return;
    }
    this.withdraw.emit({amount: this.amountValue, id: this.account.accountId})
    this.amountValue = 0;
  }

  public onDeposit(){
    this.deposit.emit({amount: this.amountValue, id: this.account.accountId})
    this.amountValue = 0;
  }
}
