import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError, Subject, Subscription, takeUntil, tap } from 'rxjs';
import { CDBResult } from 'src/app/models/cdbResult';
import { CalculatorCDBService } from 'src/app/services/calculator-cdb.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit, OnDestroy {
  private unsubscribe$ = new Subject<void>();
  private subscription!: Subscription;
  constructor(private fb: FormBuilder, private service: CalculatorCDBService) {

  }
  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
    this.subscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  formGroup!: FormGroup;
  result!: CDBResult;

  initializeForm() {
    this.formGroup = this.fb.group({
      amount: ['', [Validators.required, Validators.min(1)]],
      months: ['', [Validators.required, Validators.min(1)]]
    });
  }

  submitForm(data: any) {
    console.log(data);
    this.service.calculateCDB(data).pipe(tap((response) => {
      this.result = response as CDBResult;
    }),
      catchError((e) => {
        throw new Error('error');
      }),
      takeUntil(this.unsubscribe$)
    ).subscribe();

  }


}
