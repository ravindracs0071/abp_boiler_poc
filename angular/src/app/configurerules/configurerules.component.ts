import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '../../shared/paged-listing-component-base';
import {
  ConfigureRuleServiceProxy,
  ConfigureRuleDto,
  ConfigureRuleDtoListResultDto
} from '../../shared/service-proxies/service-proxies';
import { CreateConfigureRuleDialogComponent } from './create-configurerule/create-configurerule-dialog.component';
import { EditConfigureRuleDialogComponent } from './edit-configurerule/edit-configurerule-dialog.component';

class PagedConfigureRulesRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: './configureRules.component.html',
  animations: [appModuleAnimation()]
})
export class ConfigureRulesComponent extends PagedListingComponentBase<ConfigureRuleDto> {
  configureRules: ConfigureRuleDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _configureRulesService: ConfigureRuleServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedConfigureRulesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._configureRulesService
      .getConfigureRules()
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: ConfigureRuleDtoListResultDto) => {
        this.configureRules = result.items;
      });
  }

  delete(configureRule: ConfigureRuleDto): void {

  }

  createConfigureRule(): void {
    this.showCreateOrEditConfigureRuleDialog();
  }

  editConfigureRule(configureRule: ConfigureRuleDto): void {
    this.showCreateOrEditConfigureRuleDialog(configureRule.id);
  }

  showCreateOrEditConfigureRuleDialog(id?: number): void {
    let createOrEditConfigureRuleDialog: BsModalRef;
    if (!id) {
      createOrEditConfigureRuleDialog = this._modalService.show(
        CreateConfigureRuleDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditConfigureRuleDialog = this._modalService.show(
        EditConfigureRuleDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditConfigureRuleDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
