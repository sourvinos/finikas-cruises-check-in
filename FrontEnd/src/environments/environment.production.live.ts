// ng build --output-path="release" --configuration=production-live

export const environment = {
    apiUrl: 'https://appfinikascruises.com/api',
    url: 'https://appfinikascruises.com',
    appName: 'Finikas Cruises',
    clientUrl: 'https://appfinikascruises.com',
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
