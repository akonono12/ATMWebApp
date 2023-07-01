import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Account } from './models/account';
import { TransactionHistory } from './models/transaction-history';

@Injectable({
  providedIn: 'root'
})
export class AtmService {
 private baseUrl:string = environment.BaseUrl;
 constructor(private httpClient: HttpClient) { }

 public login(pin:number,password:string){
  return this.httpClient.post<any>(`${this.baseUrl}login`,{"password":password,"pin":pin})
 }

 public addCash(accountId:string,cash:number){
  return this.httpClient.put<boolean>(`${this.baseUrl}add`,{"accountId":accountId,"amount":cash})
 }

 public withdrawCash(accountId:string,cash:number){
  return this.httpClient.put<boolean>(`${this.baseUrl}withdraw`,{"accountId":accountId,"amount":cash})
 }

 public getAccount(accountId:string){
  return this.httpClient.get<Account>(`${this.baseUrl}account/${accountId}`)
 }


 public getTransactionHistories(accountId:string){
  return this.httpClient.get<TransactionHistory[]>(`${this.baseUrl}transaction-histories/${accountId}`)
 }

}
