import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { PagingModel } from '../../../models/PagingModel';
import { NgbModal, NgbModalRef, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToasterService } from 'angular2-toaster';
import { DialogService } from '../../../components/dialog/dialog.service';
import { PersonModalComponent } from './PersonModal.component';
import { PersonService } from '../../../services/generated/PersonService';
import { Person } from '../../../models/Person';

@Component({
  selector: 'app-list-person',
  templateUrl: './PersonIndex.component.html'
})
export class PersonIndexComponent implements OnInit, OnChanges {
    private _edit = false;
    paging: PagingModel<Person>;
    screen = 'Person';
    appErrorMessage: any;
    person: Person;
    personList: Person[];
    @Input() autoLoad = true;
    private modalRef: NgbModalRef;

    constructor(
      private _service: PersonService,
      public translate: TranslateService,
      private _modalService: NgbModal,
      private _toasterService: ToasterService,
      private _dialogService: DialogService) {
        this.paging = _service.page;
        this.paging.orderBy = 'Id';
        this.person = new Person();
    }

    ngOnInit() {
      this.load();
      this._service.on('Person-save').subscribe((data) => {
        this.pageChanged();
        this.hideModal();
      });
    }

    ngOnChanges(changes: SimpleChanges) {
    }

    hideModal() {
      this.modalRef.close();
    }

    private openModal() {
      const options = <NgbModalOptions>{ size: 'lg', backdrop: 'static', windowClass: 'modal-primary'};
      this.modalRef  = this._modalService.open(PersonModalComponent, options);
      this.modalRef.componentInstance.name = 'personModal';
      this.modalRef.componentInstance.edit = this._edit;
      this.modalRef.componentInstance.entity = this.person;
    }

    pageChanged() {
      this.autoLoad = true;
      this.load();
    }

    load() {
      if (!this.autoLoad) {
        return;
      }

      this.getAll();
    }

    public duplicate(entity: Person) {
      const objToDup = Object.assign({}, entity);
      delete objToDup.id;
      this.openEdit(objToDup, true);
    }

    public getAll() {
      this._service.getPage(this.paging).subscribe(
      result => {
        this.paging.totalCount = result.totalCount;
        this.personList = result.list;
      },
      error => {
        this.appErrorMessage = error;
      });
    }


  public openEdit(entity?: Person, edit: boolean = false) {
    this._edit = edit;
    this.person = entity || new Person();
    this.openModal();
  }

  public async remove(person: Person, index: number) {
    const msg = this.translate.instant('PERSON.GRID.CONFIRM_DELETE');
    this._dialogService.confirm(msg, () => {
        this._service.remove(person)
        .subscribe(
            () => {
              this.personList.splice(index, 1);
              this.paging.totalCount--;
              if (this.paging.totalCount <= this.paging.size) {
                this.paging.number--;
              }
              this.getAll();
              const successMsg = this.translate.instant('PERSON.GRID.REMOVE.SUCCESS');
              this._toasterService.pop('success', this.translate.instant('APP.TOASTER.TITLE.SUCCESS'), successMsg);
            },
            error => {
              const errorMsg = this.translate.instant('PERSON.GRID.REMOVE.ERROR');
              this._toasterService.pop('error', this.translate.instant('APP.TOASTER.TITLE.ERROR'), errorMsg);
              this.appErrorMessage = error;
            });
        }, 'warning');
    }
}
