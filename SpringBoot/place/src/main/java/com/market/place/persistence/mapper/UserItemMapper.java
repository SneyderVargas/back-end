package com.market.place.persistence.mapper;


import com.market.place.domain.UserDomain;
import com.market.place.persistence.entity.UserEntity;
import org.mapstruct.InheritInverseConfiguration;
import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.Mappings;

import java.util.List;

@Mapper(componentModel = "spring")
public interface UserItemMapper {
    @Mappings({
            @Mapping(source = "id", target = "userId"),
            @Mapping(source = "name", target = "userName"),
            @Mapping(source = "surname", target = "userSurname")
    })
    UserDomain toUserDomain(UserEntity userDomain);
    List<UserDomain> toUsersDomain(List<UserEntity> usersDomain);
    @InheritInverseConfiguration
    UserEntity toUserEntity(UserDomain userEntity);
}
