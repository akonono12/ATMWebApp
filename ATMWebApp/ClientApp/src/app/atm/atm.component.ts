import { AtmService } from './shared/atm.service';
import { Component, OnInit } from '@angular/core';
import { Account } from './shared/models/account';
import { TransactionHistory } from './shared/models/transaction-history';

@Component({
  selector: 'app-atm',
  templateUrl: './atm.component.html',
  styleUrls: ['./atm.component.css']
})
export class AtmComponent implements OnInit {
 public isLoggedIn:boolean = false;
 public account:Account = new Account();
 public transactionHistories:TransactionHistory[] = [];
 private emptyGUID:string = "00000000-0000-0000-0000-000000000000";

  constructor(private atmService:AtmService) { }

  ngOnInit() {
  }
  public login(num:number =0,str:string =""){
    this.atmService.login(num,str).subscribe(result => {
      if(result == this.emptyGUID){
        alert("Account not found");
        return;
      }
      this.isLoggedIn = true;
      this.load(result);
    })
  }
  public load(accountId:string){
    this.getAccount(accountId);
    this.getTransactionHistories(accountId);
  }
  public getAccount(accountId:string){
    this.atmService.getAccount(accountId).subscribe(result => {

    if(this.account.accountId != this.emptyGUID){
      this.account.balance = result.balance
      this.account.lastUpdated = result.lastUpdated
     }else{
      this.account = result
     }
    })
  }

  public getTransactionHistories(accountId:string){
    this.atmService.getTransactionHistories(accountId).subscribe(result => {
     this.transactionHistories= result
    })
  }


  public validateLogin(value:any)
  {
    if(isNaN(+value)){
      this.login(0,value);
    }else{
      if(value.toString().length < 4 || value.toString().length > 6){
        alert("Pin length must not be less than to 4 and greater than 6")
        return;
      }
      this.login(+value);

    }
  }


  public withdrawCash(item:{amount:number, id:string}){
    this.atmService.withdrawCash(item.id,item.amount).subscribe(result => {
      if(!result){
        alert("Cannot withdraw cash.Please asks for assistance in the nearest bank!");
        return;
      }
      this.load(item.id);
    })
  }

  public depositCash(item:{amount:number, id:string}){
    this.atmService.addCash(item.id,item.amount).subscribe(result => {
      if(!result){
        alert("Cannot deposit cash.Please asks for assistance in the nearest bank!");
        return;
      }
      this.load(item.id);
    })
  }

  public onLogout(){
    this.isLoggedIn = false;
    this.account = new Account();
    this.transactionHistories = [];
    alert("You have successfully logged out!")
  }
}
