import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { PersonService } from '../../../services/generated/PersonService';
import { Person } from '../../../models/Person';
declare var $: any;

@Component({
  selector: 'app-form-person',
  templateUrl: './PersonEdit.component.html'
})
export class PersonEditComponent implements OnInit {


  constructor(
    private _service: PersonService,
    public translate: TranslateService,
    private _modalService: NgbModal
  ) {
    }

    @Output()
    saveEvent?: EventEmitter<Person> = new EventEmitter();

    @Input()
    person: Person;

    @Input()
    edit: boolean;

    ngOnInit() {
      this.person = this.person || new Person();
    }

    save(person: Person) {
      this._service.save(person, this.edit, $('input[type=file]'));
    }

    public closeEdit() {
    }

}
