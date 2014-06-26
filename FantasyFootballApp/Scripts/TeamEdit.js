// JavaScript source code

$(document).ready(function () {
    $('#TeamTableContainer').jtable({
        title: 'TeamTable',
        actions: {
            listAction: '/Team/TeamList',
            createAction: '/Team/CreateTeam',
            updateAction: '/Team/UpdateTeam',
            deleteAction: '/Team/DeleteTeam'
        },
        fields: {
            TeamID: {
                key: true,
                list: false
            },
            TeamName: {
                title: 'TeamName',
                width: '35%'
            },
            Abbreviation: {
                title: 'Abbreviation',
                width: '15%'
            },
            City: {
                title: 'City',
                width: '30%'
            },
            State: {
                title: 'State',
                width: '20%'
            }
        }
    });

    $('#TeamTableContainer').jtable('load');
});

