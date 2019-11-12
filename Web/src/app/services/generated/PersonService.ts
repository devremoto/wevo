import { Injectable } from '@angular/core';
import { BaseService, HttpService } from '../services';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { Person } from '../../models/Person';
import { PagingModel } from '../../models/PagingModel';

@Injectable({
  providedIn: 'root',
})
export class PersonService extends BaseService<Person> {

  constructor(protected _http: HttpService) {
    super(_http);
    this._controller = 'Person';
  }

  getOne(entity: Person): Observable<Person> {
    return this._http.get(`Person/getOne/${entity.id}`)
      .map<any, Person>((response) => response);
  }

  remove(entity: Person): Observable<Person> {
    return this.removeById(`${entity.id}`)
      .map<any, Person>((response) => response);
  }

}
