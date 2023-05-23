import { HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CalculateCDBInput } from '../models/calculateCDBInput';

@Injectable({
  providedIn: 'root'
})
export class CalculatorCDBService {

  constructor(private http:HttpClient) { }

  private baseURL = 'https://localhost:8080/api/v1/calculator';

  calculateCDB(input: CalculateCDBInput){
    const params = new HttpParams({
      fromObject: {
        months: input.months,
        amount: input.amount
      }
    });
    return this.http.get(this.baseURL, {params});
  }
}
