import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PersonService } from '../services/generated/PersonService';
import { Person } from '../models/Person';

@Component({
  selector: 'app-combo-person',
  template: `
    <select [ngModel]="model" (ngModelChange)="updateData($event)" name="person" class="{{cssClass}}" autofocus >
      <option *ngFor="let person of personList" [value]="person.id">{{person.nome}}</option>
    </select>`
})
export class ComboPersonComponent implements OnInit {
    appErrorMessage: any;
    person: Person;
    personList: Person[];

    @Input() cssClass?: string;
    @Input() model: any;
    @Output() modelChange: any = new EventEmitter();

    constructor(private _service: PersonService) {
        this._service.on('Person-save').subscribe((data) => {
            this.reload(data);
        });
    }

    updateData(event) {
        this.model = event;
        this.modelChange.emit(event);
    }

    ngOnInit() {
        this.person = new Person();
        this.getAll();
    }

    public getAll(data?: Person) {
        this._service.getAll().subscribe(
            result => {
                this.personList = result;
                    if (data) {
                        this.updateData(data.id);
                    }
            },
            error => {
                this.appErrorMessage = error;
            }
        );
    }

    public reload(data?: Person) {
        this.getAll(data);
    }
}
