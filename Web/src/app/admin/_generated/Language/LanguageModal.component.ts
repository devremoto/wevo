﻿import { Component, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ToasterService } from 'angular2-toaster';
import { LanguageService } from '../../../services/generated/LanguageService';
import { Language } from '../../../models/Language';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
declare var $: any;

@Component({
  selector: 'app-modal-language',
  templateUrl: './LanguageModal.component.html'
})
export class LanguageModalComponent {

  @Input() edit: boolean;
  @Input() entity: Language;

  constructor(
      private _translate: TranslateService,
      private _toasterService: ToasterService,
      private _service: LanguageService,
      private _activeModal: NgbActiveModal
    ) {
        this._service.on('Language-save').subscribe(data => {
          this.hideModal();
        });
    }

  save(language: Language) {
    this._service.save(language, this.edit, $('input[type=file]')).subscribe(
      () => {
        const successMsg = this._translate.instant('LANGUAGE.FORM.SAVE.SUCCESS');
        this._toasterService.pop('success', this._translate.instant('APP.TOASTER.TITLE.SUCCESS'), successMsg);
      },
      () => {
        const errorMsg = this._translate.instant('LANGUAGE.FORM.SAVE.ERROR');
        this._toasterService.pop('error', this._translate.instant('APP.TOASTER.TITLE.ERROR'), errorMsg);
      });
  }

  hideModal() {
    this._activeModal.dismiss('Cross click');
  }
}

