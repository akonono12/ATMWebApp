import { TransactionModes } from "../enums/TransactionModes.enum";

export class TransactionHistory {
  public transactionHistoryId:string = '';
  public transactionModes: TransactionModes = 0;
  public transactionDate:string = '';
  public amount:number = 0;
  constructor() {
  }
}
