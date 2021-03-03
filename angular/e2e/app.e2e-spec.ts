import { DemoProjectTemplatePage } from './app.po';

describe('DemoProject App', function() {
  let page: DemoProjectTemplatePage;

  beforeEach(() => {
    page = new DemoProjectTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
