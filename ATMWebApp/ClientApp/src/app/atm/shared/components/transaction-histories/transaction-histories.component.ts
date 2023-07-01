import { Component, Input, OnInit } from '@angular/core';
import { TransactionHistory } from '../../models/transaction-history';

@Component({
  selector: 'app-transaction-histories',
  templateUrl: './transaction-histories.component.html',
  styleUrls: ['./transaction-histories.component.css']
})
export class TransactionHistoriesComponent implements OnInit {
@Input() transactionHistories:TransactionHistory[] = []
  constructor() { }

  ngOnInit() {
  }

}
