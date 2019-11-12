import { NgModule } from '@angular/core';
import { ServiceGeneratedModule } from './generated/servicesGeneratedModule';
import { ContactCustomService } from './custom/Contact';
import { LanguageCustomService } from './custom/Language';
import { ZipCodeCustomService } from './custom/ZipCode';

@NgModule({
  imports: [ServiceGeneratedModule],
  exports: [ServiceGeneratedModule],
  declarations: [],
  providers: [
    ContactCustomService,
    ZipCodeCustomService,
    // DatePipe,
    LanguageCustomService
  ]
})
export class ServicesModule {}
