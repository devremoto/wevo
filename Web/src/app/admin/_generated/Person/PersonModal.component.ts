import { Component, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ToasterService } from 'angular2-toaster';
import { PersonService } from '../../../services/generated/PersonService';
import { Person } from '../../../models/Person';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
declare var $: any;

@Component({
  selector: 'app-modal-person',
  templateUrl: './PersonModal.component.html'
})
export class PersonModalComponent {

  @Input() edit: boolean;
  @Input() entity: Person;

  constructor(
      private _translate: TranslateService,
      private _toasterService: ToasterService,
      private _service: PersonService,
      private _activeModal: NgbActiveModal
    ) {
        this._service.on('Person-save').subscribe(data => {
          this.hideModal();
        });
    }

  save(person: Person) {
    this._service.save(person, this.edit, $('input[type=file]')).subscribe(
      () => {
        const successMsg = this._translate.instant('PERSON.FORM.SAVE.SUCCESS');
        this._toasterService.pop('success', this._translate.instant('APP.TOASTER.TITLE.SUCCESS'), successMsg);
      },
      () => {
        const errorMsg = this._translate.instant('PERSON.FORM.SAVE.ERROR');
        this._toasterService.pop('error', this._translate.instant('APP.TOASTER.TITLE.ERROR'), errorMsg);
      });
  }

  hideModal() {
    this._activeModal.dismiss('Cross click');
  }
}

