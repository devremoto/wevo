// models imports/////////////////////////////////
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthCanActivateGuard } from '../auth/auth-can-activate.guard';
import { AdminLayoutModule } from './_layout/admin-layout.module';
import { SharedModule } from '../shared/shared.module';
import { CombosModule } from '../combos/combos.module';
import { LibModule } from '../shared/libModule.module';
import { LanguageCustomService } from '../services/custom/Language';

import { LanguageEditComponent } from './_generated/Language/LanguageEdit.component';
import { LanguageIndexComponent } from './_generated/Language/LanguageIndex.component';
import { LanguageModalComponent } from './_generated/Language/LanguageModal.component';
import { PersonEditComponent } from './_generated/Person/PersonEdit.component';
import { PersonIndexComponent } from './_generated/Person/PersonIndex.component';
import { PersonModalComponent } from './_generated/Person/PersonModal.component';

@NgModule({
  declarations: [
    LanguageEditComponent,
    LanguageIndexComponent,
    LanguageModalComponent,
    PersonEditComponent,
    PersonIndexComponent,
    PersonModalComponent,
  ],
  imports: [
    SharedModule,
    LibModule,
    CombosModule,
    AdminLayoutModule,
    RouterModule.forChild([
      {
        path: 'language',
        data: { title: 'LANGUAGE.TITLE' },
        component: LanguageIndexComponent,
        canActivate: [AuthCanActivateGuard]
      },
      {
        path: 'language/:id?',
        data: { title: 'LANGUAGE.TITLE' },
        component: LanguageEditComponent,
        canActivate: [AuthCanActivateGuard]
      },
      {
        path: 'person',
        data: { title: 'PERSON.TITLE' },
        component: PersonIndexComponent,
        canActivate: [AuthCanActivateGuard]
      },
      {
        path: 'person/:id?',
        data: { title: 'PERSON.TITLE' },
        component: PersonEditComponent,
        canActivate: [AuthCanActivateGuard]
      },
    ])
  ],
  exports: [
    AdminLayoutModule,
    SharedModule,
    LanguageEditComponent,
    LanguageIndexComponent,
    LanguageModalComponent,
    PersonEditComponent,
    PersonIndexComponent,
    PersonModalComponent,
  ],
  entryComponents: [
    LanguageModalComponent,
    PersonModalComponent,
  ]
})
export class GeneratedAdminModule {
  constructor(private _languageService: LanguageCustomService) {
  }

  translate(key: string) {
    return this._languageService.translate.instant(key);
  }
}
