import { Injectable } from '@angular/core';
import { HttpService } from '../services';
import { PersonService } from '../generated/PersonService';

@Injectable({
  providedIn: 'root',
})
export class PersonCustomService extends PersonService {

  constructor(protected _http: HttpService) {
    super(_http);
  }
}
