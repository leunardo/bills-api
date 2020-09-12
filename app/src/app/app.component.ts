import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Bill } from './shared/models/bill';
import { environment } from 'src/environments/environment';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'app';

  bills$: Observable<Bill[]>;
  form: FormGroup;

  constructor(
    private httpClient: HttpClient,
    private fb: FormBuilder
  ) {
    this.getBills();
    this.initForm();
  }

  private getBills(): void {
    this.bills$ = this.httpClient.get<Bill[]>(`${environment.apiUrl}/bills`);
  }

  save(): void {
    const bill = this.form.value;

    this.httpClient.post(`${environment.apiUrl}/bills`, bill)
      .subscribe(result => {
        if (result) {
          this.initForm();
          this.getBills();
        } else {
          alert('Error saving bill!');
        }
      });
  }

  private initForm(): void {
    this.form = this.fb.group({
      name: [null, Validators.required],
      originalAmount: [null, Validators.required],
      paymentDate: [null, Validators.required],
      dueDate: [null, Validators.required]
    });
  }
}
