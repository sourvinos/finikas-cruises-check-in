// ng build --output-path="release" --configuration=production-demo

export const environment = {
    apiUrl: 'http://checkindemo-001-site1.htempurl.com/api',
    url: 'http://checkindemo-001-site1.htempurl.com',
    appName: 'Corfu Cruises',
    clientUrl: 'http://checkindemo-001-site1.htempurl.com',
    defaultLanguage: 'en-GB',
    emailFooter: {
        lineA: 'Problems or questions? Call us at +30 26620 61400',
        lineB: 'or email at info@corfucruises.com',
        lineC: '© Corfu Cruises 2023, Corfu - Greece'
    },
    dialogShieldsDirectory: 'assets/images/dialog-shields',
    featuresIconDirectory: 'assets/images/features/',
    production: true
}
